using Microsoft.AspNetCore.Mvc;
using REST_mobile.Entities;
using REST_mobile.Services;

namespace REST_mobile.Controllers;

[Route("api/login-audit-logs")]
public class LoginAuditLogsController(ICrudService<LoginAuditLog> service) : CrudControllerBase<LoginAuditLog>(service);
