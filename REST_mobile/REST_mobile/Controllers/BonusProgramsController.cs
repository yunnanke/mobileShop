using Microsoft.AspNetCore.Mvc;
using REST_mobile.Entities;
using REST_mobile.Services;

namespace REST_mobile.Controllers;

[Route("api/bonus-programs")]
public class BonusProgramsController(ICrudService<BonusProgram> service) : CrudControllerBase<BonusProgram>(service);
