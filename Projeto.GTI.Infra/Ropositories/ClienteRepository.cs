using Projeto.GTI.Domain.Entities;
using Projeto.GTI.Infra.Context;
using Projeto.GTI.Infra.Ropositories.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.GTI.Infra.Ropositories
{
    

    public class ClienteRepository : Repository<Cliente>, IClienteRepository { 
        public ClienteRepository(GTIContext context) : base(context)
        {
        }

    }
}
