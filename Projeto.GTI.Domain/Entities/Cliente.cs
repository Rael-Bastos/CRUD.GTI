using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projeto.GTI.Domain.Entities
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public DateTime? DataExpedicao { get; set; }
        public string OrgaoExpedicao { get; set; }
        public string UFExpedicao { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public EnderecoCliente EnderecoCliente { get; set; }
    }
}
