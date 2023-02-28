using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository;

[IOCRegiste(Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton)]
[IOCRegiste<ISingletonRepository>(Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton)]
public class SingletonRepository : ISingletonRepository
{
}
