using Microsoft.AspNetCore.Mvc;
using REST_mobile.Entities;
using REST_mobile.Services;

namespace REST_mobile.Controllers;

[Route("api/payments")]
public class PaymentsController(ICrudService<Payment> service) : CrudControllerBase<Payment>(service);
