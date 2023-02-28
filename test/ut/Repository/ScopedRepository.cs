using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository;

[IOCRegiste(Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped)]
[IOCRegiste<IScopedRepository>(Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped)]
public class ScopedRepository: IScopedRepository
{
}
