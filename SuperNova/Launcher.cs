using System;
using System.Threading;
using System.Device.Gpio;


namespace SuperNova
{
    public class Launcher
    {
        GpioController controller = new GpioController();
        private static readonly int pin = 23;

        public Launcher()
        {
            controller.OpenPin(pin, PinMode.Output);
        }

        public void launchTreat()
        {
            controller.Write(pin, PinValue.High);
            Thread.Sleep(100);
            controller.Write(pin, PinValue.Low);
        }
    }
}
