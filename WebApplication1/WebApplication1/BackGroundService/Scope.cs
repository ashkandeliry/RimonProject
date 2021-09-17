using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopLoginManagment.BackGroundService
{
    public abstract class Scope: BackGroundService
    {
        private IServiceScopeFactory IServiceScopeFactory;
        public Scope(IServiceScopeFactory _serviceScopeFactory) : base()
        {
            IServiceScopeFactory = _serviceScopeFactory;
        }
        protected override async Task Processor()
        {
            using (var _Scope = IServiceScopeFactory.CreateScope())
            {
                await ProcessInScope(_Scope.ServiceProvider);
            }
        }
        public abstract Task ProcessInScope(IServiceProvider ScopeserviceProvider);
    }
}
