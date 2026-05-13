using Microsoft.AspNetCore.Mvc;
using REST_mobile.Entities;
using REST_mobile.Services;

namespace REST_mobile.Controllers;

[Route("api/sessions")]
public class SessionsController(ICrudService<Session> service) : CrudControllerBase<Session>(service);
