using Microsoft.EntityFrameworkCore;
using Npgsql;
using REST_mobile.Data;
using REST_mobile.Dtos.Auth;

namespace REST_mobile.Services;

public sealed class DatabaseAuthService(MobileShopDbContext dbContext)
{
    public async Task<LoginResponse> LoginAsync(string login, string password, CancellationToken cancellationToken = default)
    {
        await using var connection = new NpgsqlConnection(dbContext.Database.GetConnectionString());
        await connection.OpenAsync(cancellationToken);

        await using var loginCommand = connection.CreateCommand();
        loginCommand.CommandText =
            """
            select "успех", "id_пользователя", "роль", "сообщение", "тип_пользователя"
            from salon_svyazi."проверить_пароль"(@login, @password)
            """;
        loginCommand.Parameters.AddWithValue("login", login);
        loginCommand.Parameters.AddWithValue("password", password);

        await using var reader = await loginCommand.ExecuteReaderAsync(cancellationToken);
        if (!await reader.ReadAsync(cancellationToken))
        {
            return new LoginResponse
            {
                Success = false,
                Message = "Не удалось выполнить вход."
            };
        }

        var isSuccess = reader.GetBoolean(0);
        int? userId = reader.IsDBNull(1) ? null : reader.GetInt32(1);
        var dbRole = reader.IsDBNull(2) ? null : reader.GetString(2);
        var message = reader.IsDBNull(3) ? "Ошибка входа." : reader.GetString(3);
        var userType = reader.IsDBNull(4) ? null : reader.GetString(4);
        await reader.CloseAsync();

        if (!isSuccess || userId is null || string.IsNullOrWhiteSpace(userType))
        {
            return new LoginResponse
            {
                Success = false,
                Message = message
            };
        }

        await using var tokenCommand = connection.CreateCommand();
        tokenCommand.CommandText = """select salon_svyazi."сгенерировать_токен"()""";
        var token = (string?)await tokenCommand.ExecuteScalarAsync(cancellationToken);

        if (string.IsNullOrWhiteSpace(token))
        {
            return new LoginResponse
            {
                Success = false,
                Message = "Не удалось создать токен."
            };
        }

        await using var sessionCommand = connection.CreateCommand();
        sessionCommand.CommandText =
            """
            select salon_svyazi."создать_сессию_после_входа"(@userType, @userId, @token)
            """;
        sessionCommand.Parameters.AddWithValue("userType", userType);
        sessionCommand.Parameters.AddWithValue("userId", userId.Value);
        sessionCommand.Parameters.AddWithValue("token", token);
        await sessionCommand.ExecuteNonQueryAsync(cancellationToken);

        return new LoginResponse
        {
            Success = true,
            Message = message,
            Token = token,
            UserId = userId,
            UserType = NormalizeUserType(userType),
            Role = NormalizeRole(userType, dbRole),
            DisplayName = login
        };
    }

    public async Task<CurrentUser?> ValidateTokenAsync(string? authorizationHeader, CancellationToken cancellationToken = default)
    {
        var token = ExtractBearerToken(authorizationHeader);
        if (string.IsNullOrWhiteSpace(token))
        {
            return null;
        }

        await using var connection = new NpgsqlConnection(dbContext.Database.GetConnectionString());
        await connection.OpenAsync(cancellationToken);

        await using var command = connection.CreateCommand();
        command.CommandText =
            """
            select "действителен", "тип_пользователя", "id_пользователя", "сообщение"
            from salon_svyazi."проверить_токен"(@token)
            """;
        command.Parameters.AddWithValue("token", token);

        await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        if (!await reader.ReadAsync(cancellationToken))
        {
            return null;
        }

        var isValid = reader.GetBoolean(0);
        if (!isValid || reader.IsDBNull(1) || reader.IsDBNull(2))
        {
            return null;
        }

        var userType = reader.GetString(1);
        var userId = reader.GetInt32(2);
        await reader.CloseAsync();

        string role;
        if (NormalizeUserType(userType) == "client")
        {
            role = "client";
        }
        else
        {
            await using var roleCommand = connection.CreateCommand();
            roleCommand.CommandText =
                """
                select "Роль"
                from salon_svyazi."учетные_записи_сотрудников"
                where "id_сотрудника" = @userId
                limit 1
                """;
            roleCommand.Parameters.AddWithValue("userId", userId);
            var dbRole = (string?)await roleCommand.ExecuteScalarAsync(cancellationToken);
            role = NormalizeRole(userType, dbRole);
        }

        return new CurrentUser
        {
            UserId = userId,
            UserType = NormalizeUserType(userType),
            Role = role,
            Token = token
        };
    }

    private static string? ExtractBearerToken(string? authorizationHeader)
    {
        if (string.IsNullOrWhiteSpace(authorizationHeader))
        {
            return null;
        }

        const string bearer = "Bearer ";
        return authorizationHeader.StartsWith(bearer, StringComparison.OrdinalIgnoreCase)
            ? authorizationHeader[bearer.Length..].Trim()
            : null;
    }

    private static string NormalizeUserType(string value)
        => value.Contains("клиент", StringComparison.OrdinalIgnoreCase) ? "client" : "employee";

    private static string NormalizeRole(string? userType, string? dbRole)
    {
        if (!string.IsNullOrWhiteSpace(userType) &&
            userType.Contains("клиент", StringComparison.OrdinalIgnoreCase))
        {
            return "client";
        }

        if (!string.IsNullOrWhiteSpace(dbRole) &&
            dbRole.Contains("администратор", StringComparison.OrdinalIgnoreCase))
        {
            return "admin";
        }

        return "consultant";
    }
}
