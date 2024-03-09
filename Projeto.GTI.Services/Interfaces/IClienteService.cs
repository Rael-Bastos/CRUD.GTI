using Projeto.GTI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.GTI.Services.Interfaces
{
    public interface IClienteService
    {
        Task<IList<Cliente>> Listar();
        Task Editar(Cliente cliente);
        Task Adicionar(Cliente cliente);
        Task Deletar(int idCliente);
        Task<Cliente> ConsultarCliente(int idCliente);

    }
}
