using Microsoft.AspNetCore.Mvc;
using REST_mobile.Entities;
using REST_mobile.Services;

namespace REST_mobile.Controllers;

[Route("api/services")]
public class ShopServicesController(ICrudService<ShopService> service) : CrudControllerBase<ShopService>(service);
