using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service;
[IOCRegiste(Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton)]
[IOCRegiste<ISingletonService>(Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton)]
public class SingletonService : ISingletonService
{
}
