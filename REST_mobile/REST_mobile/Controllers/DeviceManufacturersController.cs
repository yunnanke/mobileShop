using Microsoft.AspNetCore.Mvc;
using REST_mobile.Entities;
using REST_mobile.Services;

namespace REST_mobile.Controllers;

[Route("api/device-manufacturers")]
public class DeviceManufacturersController(ICrudService<DeviceManufacturer> service) : CrudControllerBase<DeviceManufacturer>(service);
