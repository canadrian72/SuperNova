using MQTTnet;
using MQTTnet.Client.Options;
using MQTTnet.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace SuperNova
{
    public class Launcher
    {

        public int power { get; set; }

        public Launcher(int power)
        {
            this.power = power;
        }

        public void LaunchTreat()
        {
            Program.PublishLaunch();
        }
    }
}
