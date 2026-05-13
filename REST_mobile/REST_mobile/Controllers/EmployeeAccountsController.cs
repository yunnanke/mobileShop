using Microsoft.AspNetCore.Mvc;
using REST_mobile.Entities;
using REST_mobile.Services;

namespace REST_mobile.Controllers;

[Route("api/employee-accounts")]
public class EmployeeAccountsController(ICrudService<EmployeeAccount> service) : CrudControllerBase<EmployeeAccount>(service);
