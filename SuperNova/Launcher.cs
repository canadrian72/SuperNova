using System.Threading;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.WiringPi;


namespace SuperNova
{
    public class Launcher
    {

        public void launchTreat()
        {
            Pi.Init<BootstrapWiringPi>();

            var pin = (GpioPin)Pi.Gpio[BcmPin.Gpio18];
            pin.PinMode = GpioPinDriveMode.PwmOutput;
            pin.PwmMode = PwmMode.Balanced;
            pin.PwmClockDivisor = 2;


            pin.PwmRegister = 1024;
            Thread.Sleep(5000);
           
            
            pin.PwmRegister = 0;
            Thread.Sleep(5000);
        }
    }
}
