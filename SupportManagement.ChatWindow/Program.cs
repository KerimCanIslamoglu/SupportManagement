using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SupportManagement.Helper.ApiHelper;
using SupportManagement.Model.Model;
using SupportManagement.Model.Model.Dto.Chat;
using SupportManagement.Model.Model.Dto.Team;
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

            Console.WriteLine(" Please type something and press enter...");
            await Task.Run(async () =>
            {
                while (true)
                {
                    CreateChatDto chat = new CreateChatDto
                    {
                        Content = Console.ReadLine(),
                        UserId=1
                    };

                    var result = await restApiGenerator.PostApi<ResponseModel<CreateChatDto>>(chat, "http://localhost:53502/api/Chat/CreateChat");

                    if (result.Success)
                        Console.WriteLine("OK: " + result.Message);
                    else
                        Console.WriteLine("NOK: " + result.Message);
                }
            });
        }
    }
}
