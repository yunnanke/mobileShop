using Microsoft.AspNetCore.Mvc;
using REST_mobile.Entities;
using REST_mobile.Services;

namespace REST_mobile.Controllers;

[Route("api/customer-requests")]
public class CustomerRequestsController(ICrudService<CustomerRequest> service) : CrudControllerBase<CustomerRequest>(service);
