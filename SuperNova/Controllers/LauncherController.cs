using Microsoft.AspNetCore.Mvc;


namespace SuperNova.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LauncherController : ControllerBase
    {
        [HttpPost]
        public void LaunchTreat([FromBody] Launcher launcher)
        {
            launcher.launchTreat();
        }
    }
}