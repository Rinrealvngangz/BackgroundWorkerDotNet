using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
namespace BackgroundWorker
{
    public class BackgroundLogger : BackgroundService
    {
        private readonly IWorker _worker;
        public BackgroundLogger(IWorker worker)
        {
            _worker = worker;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
           await _worker.Worker(stoppingToken,nameof(BackgroundLogger));
        }
    }
}