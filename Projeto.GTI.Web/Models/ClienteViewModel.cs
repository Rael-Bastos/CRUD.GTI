using Projeto.GTI.Domain.Entities;
using System.Runtime.CompilerServices;

namespace Projeto.GTI.Web.Models
{
    public class ClienteViewModel
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
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

        public Cliente MontarObjetoRequest()
        {
            return new Cliente()
            {
                IdCliente = IdCliente.HasValue ? IdCliente.Value : 0,
                CPF = this.CPF,
                Nome = this.Nome,
                RG = this.RG,
                DataExpedicao = Convert.ToDateTime(this.DataExpedicao),
                OrgaoExpedicao = this.OrgaoExpedicao,
                UFExpedicao = this.UFExpedicao,
                DataNascimento = Convert.ToDateTime(this.DataNascimento),
                Sexo = this.Sexo,
                EstadoCivil = this.EstadoCivil,
                EnderecoCliente = new EnderecoCliente()
                {
                    CEP = this.CEP,
                    Logradouro = this.Logradouro,
                    Numero = this.Numero,
                    Complemento = this.Complemento,
                    Bairro = this.Bairro,
                    Cidade = this.Cidade,
                    UF = this.UF
                }
            };
        }
    }
}
