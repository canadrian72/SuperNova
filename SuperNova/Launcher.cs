using System.Threading;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.WiringPi;

namespace SuperNova
{
    public class Launcher
    {
        public string launch { get; set; }
        public GpioPin pin;
        public int range;
        
        public void gpioInit()
        {
            Pi.Init<BootstrapWiringPi>();

            range = 360;
            pin = (GpioPin)Pi.Gpio[BcmPin.Gpio23];
            pin.PinMode = GpioPinDriveMode.Output;
            pin.StartSoftPwm(0, range);
        }

        public void launchTreat()
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
