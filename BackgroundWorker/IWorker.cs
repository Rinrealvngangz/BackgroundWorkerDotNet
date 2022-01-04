using System.Threading;
using System.Threading.Tasks;
namespace BackgroundWorker
{
    public interface IWorker
    {
        public Task Worker(CancellationToken cancellationToken,string name);
    }
}