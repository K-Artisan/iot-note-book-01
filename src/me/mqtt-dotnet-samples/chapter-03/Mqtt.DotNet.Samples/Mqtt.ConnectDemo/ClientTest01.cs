using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;

namespace Mqtt.ConnectDemo
{
    public class ClientTest01
    {
        private MqttClient mqttClient = null;

        private string txtPubTopic = "testTopic";

        public ClientTest01()
        {
            Task.Run(async () => { await ConnectMqttServerAsync(); });
        }

        private async Task ConnectMqttServerAsync()
        {
            if (mqttClient == null)
            {
                // Create a new MQTT client.
                var factory = new MqttFactory();
                var mqttClient = factory.CreateMqttClient();

                mqttClient.ApplicationMessageReceived += MqttClient_ApplicationMessageReceived;
                mqttClient.Connected += MqttClient_Connected;
                mqttClient.Disconnected += MqttClient_Disconnected;
            }

            try
            {
                // Create TCP based options using the builder.
                var options = new MqttClientOptionsBuilder()
                    .WithClientId("Client1")
                    .WithTcpServer("broker.hivemq.com")
                    .WithCredentials("bud", "%spencer%")
                    .WithTls()
                    .WithCleanSession()
                    .Build();



                await mqttClient.ConnectAsync(options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"连接到MQTT服务器失败！" + Environment.NewLine + ex.Message + Environment.NewLine);
            }
        }

        private void MqttClient_Connected(object sender, EventArgs e)
        {

            Console.WriteLine("已连接到MQTT服务器！" + Environment.NewLine);
        }

        private void MqttClient_Disconnected(object sender, EventArgs e)
        {
            Console.WriteLine("已断开MQTT连接！" + Environment.NewLine);
        }

        private void MqttClient_ApplicationMessageReceived(object sender, MqttApplicationMessageReceivedEventArgs e)
        {
            Console.WriteLine($">> {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}{Environment.NewLine}");
        }

        private void BtnSubscribe_ClickAsync(object sender, EventArgs e)
        {
            //string topic = "zhuti"; //txtSubTopic.Text.Trim();

            //if (string.IsNullOrEmpty(topic))
            //{
            //    Console.WriteLine("订阅主题不能为空！");
            //    return;
            //}

            //if (!mqttClient.IsConnected)
            //{
            //    Console.WriteLine("MQTT客户端尚未连接！");
            //    return;
            //}

            //mqttClient.SubscribeAsync(new List<TopicFilter> {
            //    new TopicFilter(topic, MqttQualityOfServiceLevel.AtMostOnce)
            //});

            //Console.WriteLine($"已订阅[{topic}]主题" + Environment.NewLine);
            //txtSubTopic.Enabled = false;
            //btnSubscribe.Enabled = false;
        }

        private void BtnPublish_Click(object sender, EventArgs e)
        {
            //string topic = txtPubTopic.Text.Trim();

            //if (string.IsNullOrEmpty(topic))
            //{
            //    MessageBox.Show("发布主题不能为空！");
            //    return;
            //}

            //string inputString = txtSendMessage.Text.Trim();
            //var appMsg = new MqttApplicationMessage(topic, Encoding.UTF8.GetBytes(inputString), MqttQualityOfServiceLevel.AtMostOnce, false);
            //mqttClient.PublishAsync(appMsg);
        }
    }

}

