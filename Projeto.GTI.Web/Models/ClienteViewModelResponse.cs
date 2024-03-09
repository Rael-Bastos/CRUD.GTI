using Projeto.GTI.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Projeto.GTI.Web.Models
{
    public class ClienteViewModelResponse
    {
        public int? IdCliente { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public string DataExpedicao { get; set; }
        public string OrgaoExpedicao { get; set; }
        public string UFExpedicao { get; set; }
        public string DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public EnderecoClienteViewModelResponse EnderecoCliente { get; set; }
    }
    public class EnderecoClienteViewModelResponse
    {
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
    }
}
