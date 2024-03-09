﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Projeto.GTI.Domain.Entities
{
   public class EnderecoCliente
    {
        [Key]
        public int IdEndereco { get; set; }
        public int IdCliente { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        [JsonIgnore]
        public Cliente Cliente { get; set; }
    }
}
