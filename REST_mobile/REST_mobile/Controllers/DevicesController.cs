using Microsoft.AspNetCore.Mvc;
using REST_mobile.Entities;
using REST_mobile.Services;

namespace REST_mobile.Controllers;

[Route("api/devices")]
public class DevicesController(ICrudService<Device> service) : CrudControllerBase<Device>(service);
