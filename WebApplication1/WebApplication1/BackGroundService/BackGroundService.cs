using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EshopLoginManagment.BackGroundService
{
    public abstract class BackGroundService:IHostedService
    {
        private Task _ExecuteTask;
        private readonly CancellationTokenSource _StopingData = new CancellationTokenSource();
        public virtual Task StartAsync(CancellationToken cancellationToken)
        {
            _ExecuteTask = ExeceuteAsync(_StopingData.Token);

            if (_ExecuteTask.IsCompleted)
                return _ExecuteTask;

            return Task.CompletedTask;
        }
        public virtual async Task StopAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken == null)
                return;

            try
            {
                _StopingData.Cancel();
            }
            finally
            {
                await Task.WhenAny(_ExecuteTask, Task.Delay(Timeout.Infinite, cancellationToken));
            }
        }
        protected virtual async Task  ExeceuteAsync(CancellationToken _cancellationToken)
        {
            do
            {
                await Processor();
                await Task.Delay(1000, _cancellationToken);//10 second
            }
            while (!_cancellationToken.IsCancellationRequested);
        }
        protected abstract Task Processor();
    }
}
