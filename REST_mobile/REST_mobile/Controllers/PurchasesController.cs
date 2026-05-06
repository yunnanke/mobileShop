using Microsoft.AspNetCore.Mvc;
using REST_mobile.Entities;
using REST_mobile.Services;

namespace REST_mobile.Controllers;

[Route("api/purchases")]
public class PurchasesController(ICrudService<Purchase> service) : CrudControllerBase<Purchase>(service);
