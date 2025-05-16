using LibGit2Sharp;
using Microsoft.AspNetCore.Mvc;

namespace MetricCollector.Controllers;

[ApiController]
[Route("[controller]")]
public class CollectorController : ControllerBase
{
    private readonly ILogger<CollectorController> _logger;

    public CollectorController(ILogger<CollectorController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Collect([FromBody] string repoUrl)
    {
        if (Directory.Exists(localPath))
        {
            Directory.Delete(localPath, true);
        }

        Repository.Clone(repoUrl, localPath);

        try
        {

            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error saving metric");

            return StatusCode(500, "Internal server error");
        }
    }
}