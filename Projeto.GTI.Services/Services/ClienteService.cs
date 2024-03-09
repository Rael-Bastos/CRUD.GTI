using Projeto.GTI.Domain.Entities;
using Projeto.GTI.Infra.Ropositories.Interface;
using Projeto.GTI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.GTI.Services.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IList<Cliente>> Listar() 
        {
            var clientes = await _clienteRepository.GetAll(includes => includes.EnderecoCliente);

            return clientes;
        }
        
        public async Task Editar(Cliente cliente)
        {
            _clienteRepository.AlterarAsync(cliente);
        }

        public async Task Adicionar (Cliente cliente)
        {
            _clienteRepository.Save (cliente);
        }

        public async Task Deletar (int idCliente)
        {
            var clientes = await _clienteRepository.GetAll();
            if (clientes.Count > 0)
            {
                var cliente = clientes.Where(x => x.IdCliente == idCliente).FirstOrDefault();
                _clienteRepository.Delete(cliente);
            }
        }

        public async Task<Cliente> ConsultarCliente(int idCliente)
        {
            var cliente =  _clienteRepository.GetById(c => c.IdCliente == idCliente, includes => includes.EnderecoCliente);
            return cliente;
           
        }

    }
}
