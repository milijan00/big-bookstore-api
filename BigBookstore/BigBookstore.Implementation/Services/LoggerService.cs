using BigBookstore.Application.Services;
using BigBookstore.Domain.Entities;
using BigBookstore.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly ApplicationService service;

        public LoggerService(ApplicationService service)
        {
            this.service = service;
        }
        public async  Task Log(string message, string stackTrace)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException("Exceptions's message must not be empty.");
            }
            await this.service.Entity<LoggedException>().AddAsync(new LoggedException
            {
                Id = Guid.NewGuid(),
                Message = message,
                StackTrace = stackTrace
            });
            await this.service.SaveChangesAsync();
        }
    }
}
