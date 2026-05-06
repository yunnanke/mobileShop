using Microsoft.AspNetCore.Mvc;
using REST_mobile.Entities;
using REST_mobile.Services;

namespace REST_mobile.Controllers;

[Route("api/positions")]
public class PositionsController(ICrudService<Position> service) : CrudControllerBase<Position>(service);
