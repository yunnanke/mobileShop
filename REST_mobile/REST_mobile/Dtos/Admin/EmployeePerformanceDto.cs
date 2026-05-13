namespace REST_mobile.Dtos.Admin;

public sealed class EmployeePerformanceDto
{
    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; } = string.Empty;

    public string? PositionName { get; set; }

    public int SalesCount { get; set; }

    public int RepairsCount { get; set; }

    public int ContractsCount { get; set; }
}
