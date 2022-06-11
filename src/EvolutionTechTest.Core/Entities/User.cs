
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvolutionTechTest.Core.Entities
{
    public class User
    {
        [Column("UsuID")]
        public int Id { get; set; }
        [Column("UsuNombre")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Column("UsuPass")]
        [MaxLength(20)]
        public string Password { get; set; }
    }
}
