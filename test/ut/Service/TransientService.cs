using IRepository;
using IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service;

[IOCRegiste]
[IOCRegiste<ITransientService>]
public class TransientService : ITransientService
{
    public TransientService(ITransientRepository transientRespository)
    {
        TransientRespository = transientRespository;
    }

    public ITransientRepository TransientRespository { get; }

    public string Invoke() => TransientRespository.Get();
}
