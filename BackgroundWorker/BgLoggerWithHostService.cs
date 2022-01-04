using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BackgroundWorker
{
    public class BgLoggerWithHostService : IHostedService
    {
        private readonly Task _completedTask = Task.CompletedTask;
        private readonly ILogger<BgLoggerWithHostService> _logger;
        private readonly IWorker _worker;
     
       
       
        public BgLoggerWithHostService(IWorker worker, ILogger<BgLoggerWithHostService> logger)
        {
            _logger = logger;
            _worker = worker;
        }

        public  Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("{Service} is running.", nameof(BgLoggerWithHostService));
     
             _worker.Worker(stoppingToken,nameof(BgLoggerWithHostService));
             return _completedTask;
        }


        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                "{Service} is stopping.", nameof(BgLoggerWithHostService));
            return _completedTask;
        }

       
     }
    
}