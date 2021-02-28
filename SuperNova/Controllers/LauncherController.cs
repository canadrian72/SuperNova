using Microsoft.AspNetCore.Mvc;


namespace SuperNova.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LauncherController : ControllerBase
    {
        Launcher launcher = new Launcher();
        public LauncherController()
        {
            launcher.gpioInit();
        }

        [HttpPost]
        public void LaunchTreat([FromBody] Launcher launcher)
        {
            launcher.launchTreat();
        }
    }
}
