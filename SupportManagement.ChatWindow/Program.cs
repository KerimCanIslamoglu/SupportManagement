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
using System.Threading.Tasks;

namespace SupportManagement.ChatWindow
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

                Console.WriteLine(" [*] Users chat window.");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var routingKey = ea.RoutingKey;
                    Console.WriteLine("'{0}'", message);
                    Console.WriteLine("");
                };
                channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

                Console.WriteLine(" Please type something and press enter...");
                await Task.Run(async () =>
                {
                    while (true)
                    {
                        CreateChatDto chat = new CreateChatDto
                        {
                            Content = Console.ReadLine(),
                            UserId = 1,
                            IsSentByUser=true
                        };

                        var result = await restApiGenerator.PostApi<ResponseModel<CreateChatDto>>(chat, "http://localhost:53502/api/Chat/CreateChat");

                        if (!result.Success)
                            Console.WriteLine(result.Message);
                    }
                });
            }
        }
    }
}
