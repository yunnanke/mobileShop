using Microsoft.AspNetCore.Mvc;
using REST_mobile.Entities;
using REST_mobile.Services;

namespace REST_mobile.Controllers;

[Route("api/mobile-operators")]
public class MobileOperatorsController(ICrudService<MobileOperator> service) : CrudControllerBase<MobileOperator>(service);
