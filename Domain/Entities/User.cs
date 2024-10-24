using Domain.Entities.Enums;
using Domain.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Users")]
    public class User : Person
    {
        [Column]
        [JsonPropertyName("Documento")]
        [JsonIgnore]
        public override string? Document { get; set; }


        [Column]
        [JsonIgnore]
        [JsonPropertyName("Tipo")]
        public override int Type { get; set; }

        [Column]
        [JsonPropertyName("DataAniversario")]
        public DateTime Birthday { get; set; }

        [Column]
        [JsonIgnore]
        [JsonPropertyName("EnderecoId")]
        public override int? AddressId { get; set; }


        [Required]
        [JsonPropertyName("CPF")]
        public string CPF
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Document) && !isCPFValid()) throw new UserInvalidCPF("Número de CPF inválido");
                return this.Document;
            }
            set
            {
                this.Document = value;
            }
        }

        [JsonPropertyName("TipoDeAcesso")]
        public override PersonRoles Role
        {
            get
            {
                return PersonRoles.User;
            }
        }

        private bool isCPFValid()
        {

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            this.Document = this.Document.Trim();
            this.Document = this.Document.Replace(".", "").Replace("-", "");
            if (this.Document.Length != 11)
                return false;
            tempCpf = this.Document.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return this.Document.EndsWith(digito);







        }
    }
}