using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRepository;

namespace Repository;

[IOCRegiste]
[IOCRegiste<ITransientRepository>]
public class TransientRepository : ITransientRepository
{
    public string Get() => "halo";
}
