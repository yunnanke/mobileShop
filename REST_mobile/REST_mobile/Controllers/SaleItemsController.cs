using Microsoft.AspNetCore.Mvc;
using REST_mobile.Entities;
using REST_mobile.Services;

namespace REST_mobile.Controllers;

[Route("api/sale-items")]
public class SaleItemsController(ICrudService<SaleItem> service) : CrudControllerBase<SaleItem>(service);
