

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvolutionTechTest.Core.Entities
{
    public class Product
    {
        [Column("ProID")]
        public int Id { get; set; }
        [Column("ProDesc")]
        [MaxLength(50)]
        public string Description { get; set; }
        [Column("ProValor", TypeName ="money" )]
        public decimal Value { get; set; }
    }
}
