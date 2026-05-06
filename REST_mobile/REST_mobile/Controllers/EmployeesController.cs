using Microsoft.AspNetCore.Mvc;
using REST_mobile.Entities;
using REST_mobile.Services;

namespace REST_mobile.Controllers;

[Route("api/employees")]
public class EmployeesController(ICrudService<Employee> service) : CrudControllerBase<Employee>(service);
