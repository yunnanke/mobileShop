using Microsoft.AspNetCore.Mvc;
using REST_mobile.Entities;
using REST_mobile.Services;

namespace REST_mobile.Controllers;

[Route("api/sim-cards")]
public class SimCardsController(ICrudService<SimCard> service) : CrudControllerBase<SimCard>(service);
