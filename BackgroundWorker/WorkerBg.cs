using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
namespace BackgroundWorker
{
    public class WorkerBg : IWorker
    {
        private readonly ILogger<WorkerBg> _logger;
        private int number = 0;
       
        public WorkerBg(ILogger<WorkerBg> logger)
        {
            _logger = logger;
         
        }
        public async Task Worker(CancellationToken cancellationToken,string name)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                Interlocked.Increment(ref number);
                _logger.LogInformation("{name} running worker log Info: {number}",name,number);
              await  Task.Delay(3000, cancellationToken);
            }
            
        }
    }
}