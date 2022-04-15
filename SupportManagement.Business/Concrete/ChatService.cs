using RabbitMQ.Client;
using SupportManagement.Business.Abstract;
using SupportManagement.DataAccess.Abstract;
using SupportManagement.Entities;
using SupportManagement.Model.Model;
using SupportManagement.Model.Model.Dto.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportManagement.Business.Concrete
{
    public class ChatService : IChatService
    {
        private IChatDal _chatDal;
        private ITeamDal _teamDal;
        private ITeamService _teamService;

        public ChatService(IChatDal chatDal, ITeamDal teamDal, ITeamService teamService)
        {
            _chatDal = chatDal;
            _teamDal = teamDal;
            _teamService = teamService;
        }

        public ResponseModel<CreateChatDto> CreateChat(CreateChatDto createChatDto)
        {
            //DateTime.Now.TimeOfDay

            var currentTime = new TimeSpan(10, 0, 0);  // for test cases

            //var teams = _teamDal
            //    .GetAll(x => x.ShiftStarts <= DateTime.Now.TimeOfDay
            //    && x.ShiftEnds >= DateTime.Now.TimeOfDay
            //    && x.IsOverflowTeam==false)
            //    .FirstOrDefault();

            //var teamMembers = _teamService.GetAvailableTeamWithAllTheirMembers();

            createChatDto.TeamMemberId = 1;

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "chat", type: "direct");

                var message = createChatDto.Content;
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "chat",
                                     routingKey: "member_1", //for test
                                     basicProperties: null,
                                     body: body);
            }

            var response = new ResponseModel<CreateChatDto>();

            _chatDal.Create(new Chat
            {
                Content = createChatDto.Content,
                UserId=Convert.ToInt32(createChatDto.UserId),
                TeamMemberId= Convert.ToInt32(createChatDto.TeamMemberId),
                SentOn = DateTime.Now
            });

            response.Success = true;
            response.StatusCode = 200;
            response.Message = "Success";
            response.Response = null;

            return response;
        }
    }
}
