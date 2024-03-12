using B.Service.Infrastructure.Requests;
using B.Service.Models;
using B.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace A.Api.Controllers;
public class SettingsController : BaseController
{
    private readonly ISettingsService _settingsService;

    public SettingsController(ISettingsService settingsService)
    {
        _settingsService = settingsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetSettings()
    {
        return Ok(await _settingsService.GetSettingsAsync());
    }

    [HttpPost]
    public async Task<IActionResult> SaveSettings(SaveSettingsReq settings)
    {
        await _settingsService.SaveSettingsAsync(settings);

        return Ok("Settings successfully changed");
    }
}
