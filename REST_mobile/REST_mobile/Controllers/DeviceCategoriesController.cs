using Microsoft.AspNetCore.Mvc;
using REST_mobile.Entities;
using REST_mobile.Services;

namespace REST_mobile.Controllers;

[Route("api/device-categories")]
public class DeviceCategoriesController(ICrudService<DeviceCategory> service) : CrudControllerBase<DeviceCategory>(service);
