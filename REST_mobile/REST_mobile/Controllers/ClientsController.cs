using Microsoft.AspNetCore.Mvc;
using REST_mobile.Entities;
using REST_mobile.Services;

namespace REST_mobile.Controllers;

[Route("api/clients")]
public class ClientsController(ICrudService<Client> service) : CrudControllerBase<Client>(service);
