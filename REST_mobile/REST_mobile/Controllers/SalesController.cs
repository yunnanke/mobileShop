using Microsoft.AspNetCore.Mvc;
using REST_mobile.Entities;
using REST_mobile.Services;

namespace REST_mobile.Controllers;

[Route("api/sales")]
public class SalesController(ICrudService<Sale> service) : CrudControllerBase<Sale>(service);
