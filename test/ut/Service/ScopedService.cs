using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service;
[IOCRegiste(Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped)]
[IOCRegiste<IScopedService>(Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped)]
public class ScopedService: IScopedService
{
}
