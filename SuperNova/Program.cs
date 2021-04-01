using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Server;
using System;
using System.Threading;

namespace SuperNova
{
    public class Program
    {
        public static IMqttClient mqttClient = null;

        public static void Main(string[] args)
        {
            MqttInit();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static async void MqttInit()
        {
            if (mqttClient == null)
            {
                mqttClient = new MqttFactory().CreateMqttClient();
                var options = new MqttClientOptionsBuilder()
                                .WithTcpServer("10.0.0.169", 1883) 
                                .Build();

                await mqttClient.ConnectAsync(options);
                MqttConnectToTopic();
                PublishLaunch();
                Console.WriteLine("MQTT Server Started. Is Connected? "+mqttClient.IsConnected);
            }
        }

        public static void MqttConnectToTopic()
        {
            mqttClient.UseConnectedHandler(async e =>
            {
                Console.WriteLine("### CONNECTED WITH SERVER ###");

                await mqttClient.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic("SuperNova").Build());

                Console.WriteLine("### SUBSCRIBED ###");
            });
        }

        public static async void PublishLaunch()
        {
            var message = new MqttApplicationMessageBuilder()
                .WithTopic("SuperNova")
                .WithPayload("Launch")
                .WithExactlyOnceQoS()
                .WithRetainFlag()
                .Build();

            await mqttClient.PublishAsync(message, CancellationToken.None);
        }
    }
}
