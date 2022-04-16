using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SupportManagement.Helper.ApiHelper;
using SupportManagement.Model.Model;
using SupportManagement.Model.Model.Dto.Chat;
using SupportManagement.Model.Model.Dto.Team;
using SupportManagement.Model.Model.Dto.TeamMember;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SupportManagement.ChatCoordinator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var restApiGenerator = new RestApiGenerator();

            var teamMembers = await restApiGenerator.GetApi<ResponseModel<List<TeamMemberDto>>>("http://localhost:53502/api/TeamMember/GetTeamMembers");

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "chat", type: "direct");

                var queueName = channel.QueueDeclare().QueueName;

                foreach (var teamMember in teamMembers.Response)
                {
                    channel.QueueBind(queue: queueName,
                                exchange: "chat",
                                routingKey: teamMember.QueueName);
                }

                Console.WriteLine(" [*] Waiting for chats.");
                Console.WriteLine(" Please type something and press enter...");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var routingKey = ea.RoutingKey;
                    Console.WriteLine("'{0}':'{1}'", routingKey, message);
                    Console.WriteLine("");
                };
                channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

                Console.ReadKey();
            }
        }
    }
}
