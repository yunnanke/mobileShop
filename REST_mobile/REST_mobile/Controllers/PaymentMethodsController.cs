using Microsoft.AspNetCore.Mvc;
using REST_mobile.Entities;
using REST_mobile.Services;

namespace REST_mobile.Controllers;

[Route("api/payment-methods")]
public class PaymentMethodsController(ICrudService<PaymentMethod> service) : CrudControllerBase<PaymentMethod>(service);
