### About
- Basic support management application with .Net 5 and RabbitMQ.

### Tech Stack

- C#, .Net 5.0, RabbitMQ, Entity Framework Core, Code First, MSSQL, Swagger

### Requirements

- .Net 5.0, RabbitMQ (or use docker instead) and Sql Server must be installed on your machine.

### Docker for RabbitMQ

- docker run -d --hostname my-rabbitmq-server --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management

### For starter

- Please make sure to set multiple startup projects which are SupportManagement.Api, SupportManagement.ChatCoordinator and SupportManagement.ChatWindow.

- Before you get started please change the connection string in the following directory;
SupportManagement.DataAccess -> Context -> ApplicationDbContext

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           //change here.
		   optionsBuilder.UseSqlServer(@"Server=MSI\MSSQLSERVER14;Database=SupportManagementDb;Trusted_Connection=True;");  
        }

- The database and the tables would be created on application start and all the tables would seeded with datas (Teams, TeamMembers, Seniority etc.)

