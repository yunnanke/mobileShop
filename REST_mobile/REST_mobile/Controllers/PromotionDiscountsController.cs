using Microsoft.AspNetCore.Mvc;
using REST_mobile.Entities;
using REST_mobile.Services;

namespace REST_mobile.Controllers;

[Route("api/promotion-discounts")]
public class PromotionDiscountsController(ICrudService<PromotionDiscount> service) : CrudControllerBase<PromotionDiscount>(service);
