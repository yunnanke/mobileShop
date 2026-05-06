using Microsoft.AspNetCore.Mvc;
using REST_mobile.Entities;
using REST_mobile.Services;

namespace REST_mobile.Controllers;

[Route("api/device-repairs")]
public class DeviceRepairsController(ICrudService<DeviceRepair> service) : CrudControllerBase<DeviceRepair>(service);
