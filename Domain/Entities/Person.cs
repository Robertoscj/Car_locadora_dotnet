using Domain.Entities.Enums;
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
    public class Person
    {
        [Key]
        [Column]
        public int Id { get; set; }

        [Column]
        [Required]
        [MaxLength(100)]
        [JsonPropertyName("Nome")]
        public virtual string? Name { get; set; }

        [Column]
        [Required]
        [MaxLength(15)]
        [JsonPropertyName("Documento")]
        public virtual string? Document { get; set; }

        [Column]
        [Required]
        [JsonPropertyName("Tipo")]
        public virtual int Type { get; set; }

        [Column]
        [Required]
        [MaxLength(150)]
        [JsonPropertyName("Senha")]
        public virtual string? Password { get; set; }

        [Column]
        [JsonPropertyName("EnderecoId")]
        public virtual int? AddressId { get; set; }

        [JsonPropertyName("TipoDeAcessos")]
        public virtual PersonRoles Role { get { return (PersonRoles)Enum.ToObject(typeof(PersonRoles), this.Type); } }

    }
}
