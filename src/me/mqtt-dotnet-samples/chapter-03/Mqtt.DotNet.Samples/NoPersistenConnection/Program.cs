using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using Newtonsoft.Json;
using System;

namespace NoPersistenConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new MQTT client.
            var factory = new MqttFactory();
            var mqttClient = factory.CreateMqttClient();

            try
            {
                // Use TCP connection.
                var options = new MqttClientOptionsBuilder()
                    .WithTcpServer("mqtt.eclipseprojects.io", 1883) // Port is optional
                    .WithClientId("mqtt_sample_id_clean_session")
                    .WithCleanSession(true) //false:建立一个持久会话的连接，Broker不存储该Client订阅的主题和未接受的消息
                    .Build();

                mqttClient.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(OnAppMessage);
                mqttClient.ConnectedHandler = new MqttClientConnectedHandlerDelegate(OnConnected);
                mqttClient.DisconnectedHandler = new MqttClientDisconnectedHandlerDelegate(OnDisconnected);

                mqttClient.ConnectAsync(options).Wait();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"连接到MQTT服务器失败！" + Environment.NewLine + ex.Message + Environment.NewLine);
            }

            Console.WriteLine($"输入任意键退出");
            Console.ReadKey();
        }


        private static void OnAppMessage(MqttApplicationMessageReceivedEventArgs e)
        {
        }

        private static void OnConnected(MqttClientConnectedEventArgs e)
        {
            Console.WriteLine("已连接到MQTT服务器！");

            //非持久性会话， Session Present Flag 永远是 False
            Console.WriteLine($"MqttClientConnectedEventArgs:{Environment.NewLine}{JsonConvert.SerializeObject(e)}");
        }

        private static void OnDisconnected(MqttClientDisconnectedEventArgs e)
        {
            Console.WriteLine("连接已经断开！");
        }

    }
}
