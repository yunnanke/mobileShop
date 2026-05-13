using Microsoft.EntityFrameworkCore;
using Npgsql;
using REST_mobile.Data;
using REST_mobile.Dtos.Admin;
using REST_mobile.Dtos.Catalog;
using REST_mobile.Dtos.ClientPortal;
using REST_mobile.Dtos.Staff;

namespace REST_mobile.Services;

public sealed class PortalQueryService(MobileShopDbContext dbContext)
{
    public async Task<List<DeviceCatalogItemDto>> GetDevicesAsync(DeviceCatalogQuery query, CancellationToken cancellationToken = default)
    {
        await using var connection = await OpenConnectionAsync(cancellationToken);
        await using var command = connection.CreateCommand();
        command.CommandText =
            """
            select "id_устройства", "модель", "цена", "производитель", "остаток"
            from salon_svyazi.f_get_available_devices(
                @categoryId,
                @minPrice,
                @maxPrice,
                @limitValue,
                @offsetValue
            )
            """;
        command.Parameters.AddWithValue("categoryId", query.CategoryId is null ? DBNull.Value : query.CategoryId.Value);
        command.Parameters.AddWithValue("minPrice", query.MinPrice ?? 0m);
        command.Parameters.AddWithValue("maxPrice", query.MaxPrice ?? 999999m);
        command.Parameters.AddWithValue("limitValue", query.Limit <= 0 ? 12 : query.Limit);
        command.Parameters.AddWithValue("offsetValue", query.Offset < 0 ? 0 : query.Offset);

        var result = new List<DeviceCatalogItemDto>();
        await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            result.Add(new DeviceCatalogItemDto
            {
                Id = reader.GetInt32(0),
                Model = reader.GetString(1),
                RetailPrice = reader.GetDecimal(2),
                ManufacturerName = reader.GetString(3),
                StockCount = Convert.ToInt32(reader.GetValue(4)),
                CategoryName = string.Empty
            });
        }

        return result;
    }

    public async Task<List<TariffCatalogItemDto>> GetTariffsAsync(CancellationToken cancellationToken = default)
    {
        await using var connection = await OpenConnectionAsync(cancellationToken);
        await using var command = connection.CreateCommand();
        command.CommandText =
            """
            select "id_тарифа", "название_оператора", "название_тарифа",
                   "ежемесячная_плата", "включённые_минуты", "включённые_sms",
                   "включённый_интернет_гб", "описание"
            from salon_svyazi.v_active_tariffs_with_operator
            order by "ежемесячная_плата", "название_тарифа"
            """;

        var result = new List<TariffCatalogItemDto>();
        await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            result.Add(new TariffCatalogItemDto
            {
                Id = reader.GetInt32(0),
                OperatorName = reader.GetString(1),
                TariffName = reader.GetString(2),
                MonthlyFee = reader.GetDecimal(3),
                IncludedMinutes = reader.GetInt32(4),
                IncludedSms = reader.IsDBNull(5) ? 0 : reader.GetInt32(5),
                IncludedInternetGb = reader.GetDecimal(6),
                Description = reader.IsDBNull(7) ? null : reader.GetString(7)
            });
        }

        return result;
    }

    public async Task<List<PromotionCatalogItemDto>> GetPromotionsAsync(CancellationToken cancellationToken = default)
    {
        await using var connection = await OpenConnectionAsync(cancellationToken);
        await using var command = connection.CreateCommand();
        command.CommandText =
            """
            select "id_акции", "название_акции", "тип_скидки", "размер_скидки",
                   "дата_начала", "дата_окончания", "описание"
            from salon_svyazi.v_active_promotions
            order by "дата_окончания"
            """;

        var result = new List<PromotionCatalogItemDto>();
        await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            result.Add(new PromotionCatalogItemDto
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                DiscountType = reader.GetString(2),
                DiscountValue = reader.GetDecimal(3),
                StartDate = reader.GetFieldValue<DateOnly>(4),
                EndDate = reader.GetFieldValue<DateOnly>(5),
                Description = reader.IsDBNull(6) ? null : reader.GetString(6)
            });
        }

        return result;
    }

    public async Task<ClientProfileDto?> GetClientProfileAsync(int clientId, CancellationToken cancellationToken = default)
    {
        await using var connection = await OpenConnectionAsync(cancellationToken);
        await using var command = connection.CreateCommand();
        command.CommandText =
            """
            select c."id_клиента",
                   trim(concat_ws(' ', c."фамилия", c."имя", c."отчество")) as full_name,
                   c."телефон",
                   c.email,
                   c."дата_регистрации",
                   bp."уровень_клиента",
                   coalesce(bp."количество_баллов", 0),
                   bp."дата_последнего_начисления",
                   count(d."id_договора") filter (
                       where d."дата_окончания" is null or d."дата_окончания" >= current_date
                   ) as active_contracts_count
            from salon_svyazi."клиенты" c
            left join salon_svyazi."бонусная_программа" bp on bp."id_клиента" = c."id_клиента"
            left join salon_svyazi."договоры" d on d."id_клиента" = c."id_клиента"
            where c."id_клиента" = @clientId
            group by c."id_клиента", c."фамилия", c."имя", c."отчество", c."телефон",
                     c.email, c."дата_регистрации", bp."уровень_клиента",
                     bp."количество_баллов", bp."дата_последнего_начисления"
            """;
        command.Parameters.AddWithValue("clientId", clientId);

        await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        if (!await reader.ReadAsync(cancellationToken))
        {
            return null;
        }

        return new ClientProfileDto
        {
            ClientId = reader.GetInt32(0),
            FullName = reader.GetString(1),
            Phone = reader.GetString(2),
            Email = reader.IsDBNull(3) ? null : reader.GetString(3),
            RegistrationDate = reader.GetFieldValue<DateOnly>(4),
            ClientLevel = reader.IsDBNull(5) ? null : reader.GetString(5),
            BonusPoints = Convert.ToInt32(reader.GetValue(6)),
            LastAccrualDate = reader.IsDBNull(7) ? null : reader.GetFieldValue<DateOnly>(7),
            ActiveContractsCount = Convert.ToInt64(reader.GetValue(8))
        };
    }

    public async Task<List<ClientRepairDto>> GetClientRepairsAsync(int clientId, CancellationToken cancellationToken = default)
    {
        await using var connection = await OpenConnectionAsync(cancellationToken);
        await using var command = connection.CreateCommand();
        command.CommandText =
            """
            select r."id_ремонта", d."модель", r."серийный_номер", r."тип_неисправности",
                   r."статус", r."дата_приема", r."дата_выдачи", r."стоимость_ремонта"
            from salon_svyazi."ремонт_устройств" r
            left join salon_svyazi."устройства" d on d."id_устройства" = r."id_устройства"
            where r."id_клиента" = @clientId
            order by r."дата_приема" desc, r."id_ремонта" desc
            """;
        command.Parameters.AddWithValue("clientId", clientId);

        var result = new List<ClientRepairDto>();
        await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            result.Add(new ClientRepairDto
            {
                RepairId = reader.GetInt32(0),
                DeviceModel = reader.IsDBNull(1) ? null : reader.GetString(1),
                SerialNumber = reader.IsDBNull(2) ? null : reader.GetString(2),
                FaultType = reader.GetString(3),
                Status = reader.IsDBNull(4) ? null : reader.GetString(4),
                AcceptedAt = reader.GetFieldValue<DateOnly>(5),
                IssuedAt = reader.IsDBNull(6) ? null : reader.GetFieldValue<DateOnly>(6),
                FinalCost = reader.IsDBNull(7) ? null : reader.GetDecimal(7)
            });
        }

        return result;
    }

    public async Task<List<ClientContractDto>> GetClientContractsAsync(int clientId, CancellationToken cancellationToken = default)
    {
        await using var connection = await OpenConnectionAsync(cancellationToken);
        await using var command = connection.CreateCommand();
        command.CommandText =
            """
            select d."id_договора", d."тип_договора", d."дата_начала", d."дата_окончания",
                   d."детали_договора", s."номер_телефона", s.iccid
            from salon_svyazi."договоры" d
            left join salon_svyazi."sim_карты" s on s."id_договора" = d."id_договора"
            where d."id_клиента" = @clientId
            order by d."дата_начала" desc
            """;
        command.Parameters.AddWithValue("clientId", clientId);

        var result = new List<ClientContractDto>();
        await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            result.Add(new ClientContractDto
            {
                ContractId = reader.GetInt32(0),
                Type = reader.GetString(1),
                StartDate = reader.GetFieldValue<DateOnly>(2),
                EndDate = reader.IsDBNull(3) ? null : reader.GetFieldValue<DateOnly>(3),
                Details = reader.IsDBNull(4) ? null : reader.GetString(4),
                SimPhoneNumber = reader.IsDBNull(5) ? null : reader.GetString(5),
                SimIccid = reader.IsDBNull(6) ? null : reader.GetString(6)
            });
        }

        return result;
    }

    public async Task<ClientBonusDto?> GetClientBonusAsync(int clientId, CancellationToken cancellationToken = default)
    {
        await using var connection = await OpenConnectionAsync(cancellationToken);
        await using var command = connection.CreateCommand();
        command.CommandText =
            """
            select "id_клиента", "уровень_клиента", "количество_баллов", "дата_последнего_начисления"
            from salon_svyazi."бонусная_программа"
            where "id_клиента" = @clientId
            """;
        command.Parameters.AddWithValue("clientId", clientId);

        await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        if (!await reader.ReadAsync(cancellationToken))
        {
            return null;
        }

        return new ClientBonusDto
        {
            ClientId = reader.GetInt32(0),
            ClientLevel = reader.IsDBNull(1) ? null : reader.GetString(1),
            BonusPoints = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
            LastAccrualDate = reader.IsDBNull(3) ? null : reader.GetFieldValue<DateOnly>(3)
        };
    }

    public async Task<List<ClientPurchaseDto>> GetClientPurchasesAsync(int clientId, CancellationToken cancellationToken = default)
    {
        await using var connection = await OpenConnectionAsync(cancellationToken);
        await using var command = connection.CreateCommand();
        command.CommandText =
            """
            select p."id_продажи", p."дата_продажи", u."модель", pi."серийный_номер", u."розничная_цена"
            from salon_svyazi."продажи" p
            join salon_svyazi."позиции_продаж" pi on pi."id_продажи" = p."id_продажи"
            join salon_svyazi."устройства" u on u."id_устройства" = pi."id_устройства"
            where p."id_клиента" = @clientId
            order by p."дата_продажи" desc, p."id_продажи" desc
            """;
        command.Parameters.AddWithValue("clientId", clientId);

        var result = new List<ClientPurchaseDto>();
        await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            result.Add(new ClientPurchaseDto
            {
                SaleId = reader.GetInt32(0),
                SaleDate = reader.GetFieldValue<DateOnly>(1),
                DeviceModel = reader.GetString(2),
                SerialNumber = reader.GetString(3),
                RetailPrice = reader.GetDecimal(4)
            });
        }

        return result;
    }

    public async Task<List<ClientLookupDto>> SearchClientsAsync(string? query, CancellationToken cancellationToken = default)
    {
        await using var connection = await OpenConnectionAsync(cancellationToken);
        await using var command = connection.CreateCommand();
        command.CommandText =
            """
            select "id_клиента",
                   trim(concat_ws(' ', "фамилия", "имя", "отчество")) as full_name,
                   "телефон",
                   email
            from salon_svyazi."клиенты"
            where @query = ''
               or lower("телефон") like lower('%' || @query || '%')
               or lower("фамилия") like lower('%' || @query || '%')
               or lower("имя") like lower('%' || @query || '%')
            order by "id_клиента" desc
            limit 20
            """;
        command.Parameters.AddWithValue("query", query?.Trim() ?? string.Empty);

        var result = new List<ClientLookupDto>();
        await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            result.Add(new ClientLookupDto
            {
                ClientId = reader.GetInt32(0),
                FullName = reader.GetString(1),
                Phone = reader.GetString(2),
                Email = reader.IsDBNull(3) ? null : reader.GetString(3)
            });
        }

        return result;
    }

    public async Task<int> RegisterSaleAsync(RegisterSaleRequest request, int employeeId, CancellationToken cancellationToken = default)
    {
        await using var connection = await OpenConnectionAsync(cancellationToken);
        await using var command = connection.CreateCommand();
        command.CommandText =
            """
            select salon_svyazi.f_register_sale(@clientId, @employeeId, @serialNumbers, @paymentMethodId)
            """;
        command.Parameters.AddWithValue("clientId", request.ClientId);
        command.Parameters.AddWithValue("employeeId", employeeId);
        command.Parameters.AddWithValue("serialNumbers", request.SerialNumbers);
        command.Parameters.AddWithValue("paymentMethodId", request.PaymentMethodId);

        var saleId = await command.ExecuteScalarAsync(cancellationToken);
        return Convert.ToInt32(saleId);
    }

    public async Task<int> CreateRepairAsync(CreateRepairRequest request, int employeeId, CancellationToken cancellationToken = default)
    {
        await using var connection = await OpenConnectionAsync(cancellationToken);
        await using var command = connection.CreateCommand();
        command.CommandText =
            """
            insert into salon_svyazi."ремонт_устройств" (
                "id_клиента",
                "id_устройства",
                "серийный_номер",
                "тип_неисправности",
                "описание_проблемы",
                "статус",
                "дата_приема",
                "id_сотрудника"
            )
            values (
                @clientId,
                @deviceId,
                @serialNumber,
                @faultType,
                @problemDescription,
                'новый',
                current_date,
                @employeeId
            )
            returning "id_ремонта"
            """;
        command.Parameters.AddWithValue("clientId", request.ClientId);
        command.Parameters.AddWithValue("deviceId", request.DeviceId is null ? DBNull.Value : request.DeviceId.Value);
        command.Parameters.AddWithValue("serialNumber", request.SerialNumber ?? (object)DBNull.Value);
        command.Parameters.AddWithValue("faultType", request.FaultType);
        command.Parameters.AddWithValue("problemDescription", request.ProblemDescription ?? (object)DBNull.Value);
        command.Parameters.AddWithValue("employeeId", employeeId);

        var repairId = await command.ExecuteScalarAsync(cancellationToken);
        return Convert.ToInt32(repairId);
    }

    public async Task CloseRepairAsync(int repairId, CloseRepairRequest request, CancellationToken cancellationToken = default)
    {
        await using var connection = await OpenConnectionAsync(cancellationToken);
        await using var command = connection.CreateCommand();
        command.CommandText =
            """
            select salon_svyazi.f_close_repair(@repairId, @finalCost, @notes)
            """;
        command.Parameters.AddWithValue("repairId", repairId);
        command.Parameters.AddWithValue("finalCost", request.FinalCost);
        command.Parameters.AddWithValue("notes", request.Notes ?? string.Empty);
        await command.ExecuteNonQueryAsync(cancellationToken);
    }

    public async Task<int> CreateContractAsync(CreateContractRequest request, int employeeId, CancellationToken cancellationToken = default)
    {
        await using var connection = await OpenConnectionAsync(cancellationToken);
        await using var command = connection.CreateCommand();
        command.CommandText =
            """
            select salon_svyazi.f_create_contract_with_sim(@clientId, @employeeId, @simIccid, @contractType)
            """;
        command.Parameters.AddWithValue("clientId", request.ClientId);
        command.Parameters.AddWithValue("employeeId", employeeId);
        command.Parameters.AddWithValue("simIccid", request.SimIccid);
        command.Parameters.AddWithValue("contractType", request.ContractType);

        var contractId = await command.ExecuteScalarAsync(cancellationToken);
        return Convert.ToInt32(contractId);
    }

    public async Task<List<EmployeePerformanceDto>> GetEmployeePerformanceAsync(CancellationToken cancellationToken = default)
    {
        await using var connection = await OpenConnectionAsync(cancellationToken);
        await using var command = connection.CreateCommand();
        command.CommandText =
            """
            select e."id_сотрудника",
                   trim(concat_ws(' ', e."фамилия", e."имя", e."отчество")) as employee_name,
                   p."название_должности",
                   count(distinct s."id_продажи") as sales_count,
                   count(distinct r."id_ремонта") as repairs_count,
                   count(distinct c."id_договора") as contracts_count
            from salon_svyazi."сотрудники" e
            left join salon_svyazi."должности" p on p."id_должности" = e."id_должности"
            left join salon_svyazi."продажи" s on s."id_сотрудника" = e."id_сотрудника"
            left join salon_svyazi."ремонт_устройств" r on r."id_сотрудника" = e."id_сотрудника"
            left join salon_svyazi."договоры" c on c."id_сотрудника" = e."id_сотрудника"
            group by e."id_сотрудника", e."фамилия", e."имя", e."отчество", p."название_должности"
            order by sales_count desc, repairs_count desc, contracts_count desc
            """;

        var result = new List<EmployeePerformanceDto>();
        await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            result.Add(new EmployeePerformanceDto
            {
                EmployeeId = reader.GetInt32(0),
                EmployeeName = reader.GetString(1),
                PositionName = reader.IsDBNull(2) ? null : reader.GetString(2),
                SalesCount = Convert.ToInt32(reader.GetValue(3)),
                RepairsCount = Convert.ToInt32(reader.GetValue(4)),
                ContractsCount = Convert.ToInt32(reader.GetValue(5))
            });
        }

        return result;
    }

    private async Task<NpgsqlConnection> OpenConnectionAsync(CancellationToken cancellationToken)
    {
        var connection = new NpgsqlConnection(dbContext.Database.GetConnectionString());
        await connection.OpenAsync(cancellationToken);
        return connection;
    }
}
