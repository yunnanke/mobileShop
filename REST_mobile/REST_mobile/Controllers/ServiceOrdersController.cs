using Microsoft.AspNetCore.Mvc;
using REST_mobile.Entities;
using REST_mobile.Services;

namespace REST_mobile.Controllers;

[Route("api/service-orders")]
public class ServiceOrdersController(ICrudService<ServiceOrder> service) : CrudControllerBase<ServiceOrder>(service);
