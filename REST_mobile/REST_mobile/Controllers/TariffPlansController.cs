using Microsoft.AspNetCore.Mvc;
using REST_mobile.Entities;
using REST_mobile.Services;

namespace REST_mobile.Controllers;

[Route("api/tariff-plans")]
public class TariffPlansController(ICrudService<TariffPlan> service) : CrudControllerBase<TariffPlan>(service);
