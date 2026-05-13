using Microsoft.AspNetCore.Mvc;
using REST_mobile.Dtos.Catalog;
using REST_mobile.Services;

namespace REST_mobile.Controllers;

[ApiController]
[Route("api/catalog")]
public sealed class CatalogController(PortalQueryService portalQueryService) : ControllerBase
{
    [HttpGet("devices")]
    public async Task<ActionResult<List<DeviceCatalogItemDto>>> GetDevices([FromQuery] DeviceCatalogQuery query, CancellationToken cancellationToken)
        => Ok(await portalQueryService.GetDevicesAsync(query, cancellationToken));

    [HttpGet("tariffs")]
    public async Task<ActionResult<List<TariffCatalogItemDto>>> GetTariffs(CancellationToken cancellationToken)
        => Ok(await portalQueryService.GetTariffsAsync(cancellationToken));

    [HttpGet("promotions")]
    public async Task<ActionResult<List<PromotionCatalogItemDto>>> GetPromotions(CancellationToken cancellationToken)
        => Ok(await portalQueryService.GetPromotionsAsync(cancellationToken));
}
