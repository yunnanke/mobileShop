using Microsoft.AspNetCore.Mvc;
using REST_mobile.Entities;
using REST_mobile.Services;

namespace REST_mobile.Controllers;

[Route("api/contracts")]
public class ContractsController(ICrudService<Contract> service) : CrudControllerBase<Contract>(service);
