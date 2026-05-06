using Microsoft.AspNetCore.Mvc;
using REST_mobile.Entities;
using REST_mobile.Services;

namespace REST_mobile.Controllers;

[Route("api/warranties")]
public class WarrantiesController(ICrudService<Warranty> service) : CrudControllerBase<Warranty>(service);
