using Microsoft.Extensions.DependencyInjection;
using NCrontab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EshopLoginManagment.BackGroundService
{
    public abstract class SheduledProsessor: Scope
    {
        private CrontabSchedule _Schedule;
        private DateTime _NextRun;
        protected abstract string Schedule { get; }
        public SheduledProsessor(IServiceScopeFactory _serviceScopeFactory) : base(_serviceScopeFactory)
        {
            _Schedule = CrontabSchedule.Parse(Schedule);
            _NextRun = _Schedule.GetNextOccurrence(DateTime.Now);
        }
        protected override async Task ExeceuteAsync(CancellationToken _cancellationToken)
        {
            do
            {
                var now = DateTime.Now;
                if (now > _NextRun)
                {
                    await Processor();
                    _NextRun = _Schedule.GetNextOccurrence(DateTime.Now);
                }
                 
            }
            while (!_cancellationToken.IsCancellationRequested);
        }
    }
}
