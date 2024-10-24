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
    [Table("schedules")]
    public class schedules
    {
        [Key]
        [Column]
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [Column]
        [Required]
        [JsonPropertyName("VeiculoId")]
        public int VehicleId { get; set; }

        [Column]
        [Required]
        [JsonIgnore]
        [JsonPropertyName("Veiculo")]
        public Vehicle Vehicle { get; set; }
    }
}
