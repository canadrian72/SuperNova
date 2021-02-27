using Microsoft.AspNetCore.Mvc;
using System.Device.Gpio;
using System.Threading;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.WiringPi;

namespace SuperNova.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LauncherController : ControllerBase
    {
        public void launch()
        {
            var range = 100;
            var pin = (GpioPin)Pi.Gpio[BcmPin.Gpio23];
            pin.PinMode = GpioPinDriveMode.Output;
            pin.StartSoftPwm(0, range);

            while(true)
            {
                for (var x = 0; x <= 100; x++)
                {
                    pin.SoftPwmValue = range / 100 * x;
                    Thread.Sleep(10);
                }

                for (var x = 0; x <= 100; x++)
                {
                    pin.SoftPwmValue = range - (range / 100 * x);
                    Thread.Sleep(10);
                }
            }
        }
    }
}
