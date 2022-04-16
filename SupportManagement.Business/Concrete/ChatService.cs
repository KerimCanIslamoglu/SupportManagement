using RabbitMQ.Client;
using SupportManagement.Business.Abstract;
using SupportManagement.DataAccess.Abstract;
using SupportManagement.Entities;
using SupportManagement.Model.Model;
using SupportManagement.Model.Model.Dto.Chat;
using SupportManagement.Model.Model.Dto.SupportQueue;
using SupportManagement.Model.Model.Dto.TeamMember;
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
        private ITeamMemberDal _teamMemberDal;
        private ISupportQueueDal _supportQueueDal;
        private ITeamService _teamService;

        public ChatService(IChatDal chatDal, ITeamDal teamDal, ITeamMemberDal teamMemberDal, ISupportQueueDal supportQueueDal, ITeamService teamService)
        {
            _chatDal = chatDal;
            _teamDal = teamDal;
            _teamMemberDal = teamMemberDal;
            _supportQueueDal = supportQueueDal;
            _teamService = teamService;
        }

        public ResponseModel<CreateChatDto> CreateChat(CreateChatDto createChatDto)
        {
            var response = new ResponseModel<CreateChatDto>();

            var availableQueue = GetAvailableTeamMemberOnSupportQueue();

            if (availableQueue.Id > 0)
            {
                createChatDto.TeamMemberId = availableQueue.TeamMemberId;

                _chatDal.Create(new Chat
                {
                    Content = createChatDto.Content,
                    UserId = Convert.ToInt32(createChatDto.UserId),
                    TeamMemberId = Convert.ToInt32(createChatDto.TeamMemberId),
                    SentOn = DateTime.Now
                });

                _supportQueueDal.Update(new SupportQueue
                {
                    Id = availableQueue.Id,
                    AssignedOn = DateTime.Now,
                    IsAvailable = false,
                    TeamMemberId = availableQueue.TeamMemberId,
                    CreatedOn = availableQueue.CreatedOn
                });

                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "chat", type: "direct");

                    var message = createChatDto.Content;
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: "chat",
                                         routingKey: availableQueue.TeamMember?.QueueName,
                                         basicProperties: null,
                                         body: body);
                }

                response.Success = true;
                response.StatusCode = 200;
                response.Message = "Success";
                response.Response = null;
            }
            else
            {
                response.Success = false;
                response.StatusCode = 404;
                response.Message = "No agents available at the moment";
                response.Response = null;
            }

            return response;
        }

        public SupportQueueDto GetAvailableTeamMemberOnSupportQueue()
        {
            //DateTime.Now.TimeOfDay
            //var currentTime = new TimeSpan(19, 0, 0);  // for test cases

            var response = new SupportQueueDto();

            var team = _teamDal
                .GetAll(x => x.ShiftStarts <= DateTime.Now.TimeOfDay
                          && x.ShiftEnds >= DateTime.Now.TimeOfDay
                          && x.IsOverflowTeam == false)
                .FirstOrDefault();

            if (team != null)
            {
                var supportQueue = _supportQueueDal.GetSupportQueueByTeamId(team.Id);

                if(supportQueue==null || supportQueue.Count == 0)
                {
                    var supportQueueList = new List<SupportQueue>();
                    var teamMembers = _teamMemberDal.GetTeamMembersByTeamId(team.Id);

                    foreach (var teamMember in teamMembers)
                    {
                        int queueLength = Convert.ToInt32(teamMember.Seniority.Multiplier * (10) * (1.5));

                        for (int i = 0; i < queueLength; i++)
                        {
                            var model = new SupportQueue()
                            {
                                IsAvailable = true,
                                CreatedOn = DateTime.Now,
                                TeamMemberId = teamMember.Id,
                                AssignedOn = null
                            };

                            supportQueueList.Add(model);
                        }
                    }

                    if (team.WorksInOfficeHours)
                    {
                        var overflowTeam = _teamDal.GetOne(x => x.IsOverflowTeam == true);

                        var overflowTeamMembers = _teamMemberDal.GetTeamMembersByTeamId(overflowTeam.Id);

                        foreach (var overflowTeamMember in overflowTeamMembers)
                        {
                            int queueLength = Convert.ToInt32(overflowTeamMember.Seniority.Multiplier * (10) * (1.5));

                            for (int i = 0; i < queueLength; i++)
                            {
                                var model = new SupportQueue()
                                {
                                    IsAvailable = true,
                                    CreatedOn = DateTime.Now,
                                    TeamMemberId = overflowTeamMember.Id,
                                    AssignedOn = null
                                };

                                supportQueueList.Add(model);
                            }
                        }

                    }

                    if (supportQueueList.Count > 0)
                        _supportQueueDal.CreateAll(supportQueueList);

                }

                var nextAvailableTeamMember = _supportQueueDal.GetNextAvailableSupportQueueByTeamId(team.Id);

                if (nextAvailableTeamMember != null)
                {
                    response.Id = nextAvailableTeamMember.Id;
                    response.TeamMemberId = nextAvailableTeamMember.TeamMemberId;
                    response.IsAvailable = nextAvailableTeamMember.IsAvailable;
                    response.AssignedOn = nextAvailableTeamMember.AssignedOn;
                    response.CreatedOn = nextAvailableTeamMember.CreatedOn;

                    if (nextAvailableTeamMember.TeamMember != null)
                    {
                        response.TeamMember = new TeamMemberDto
                        {
                            Id = nextAvailableTeamMember.TeamMember.Id,
                            SeniorityId = nextAvailableTeamMember.TeamMember.SeniorityId,
                            TeamId = nextAvailableTeamMember.TeamMember.TeamId,
                            QueueName = nextAvailableTeamMember.TeamMember.QueueName
                        };
                    }
                }
                else if (team.WorksInOfficeHours)
                {
                    var overflowTeam = _teamDal.GetOne(x => x.IsOverflowTeam == true);
                    var nextAvailableOverflowTeamMember = _supportQueueDal.GetNextAvailableSupportQueueByTeamId(overflowTeam.Id);

                    if (nextAvailableOverflowTeamMember != null)
                    {
                        response.Id = nextAvailableOverflowTeamMember.Id;
                        response.TeamMemberId = nextAvailableOverflowTeamMember.TeamMemberId;
                        response.IsAvailable = nextAvailableOverflowTeamMember.IsAvailable;
                        response.AssignedOn = nextAvailableOverflowTeamMember.AssignedOn;
                        response.CreatedOn = nextAvailableOverflowTeamMember.CreatedOn;

                        if (nextAvailableOverflowTeamMember.TeamMember != null)
                        {
                            response.TeamMember = new TeamMemberDto
                            {
                                Id = nextAvailableOverflowTeamMember.TeamMember.Id,
                                SeniorityId = nextAvailableOverflowTeamMember.TeamMember.SeniorityId,
                                TeamId = nextAvailableOverflowTeamMember.TeamMember.TeamId,
                                QueueName = nextAvailableOverflowTeamMember.TeamMember.QueueName
                            };
                        }
                    }
                }
            }

            return response;
        }
    }
}
