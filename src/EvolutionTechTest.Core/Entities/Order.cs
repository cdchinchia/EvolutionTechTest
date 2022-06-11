using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionTechTest.Core.Entities
{
    public class Order
    {
        [Column("PedID")]
        public int Id { get; set; }
        [Column("PedUsu")]
        public int OrderUserId { get; set; }
        [Column("PedProd")]
        public int OrderProductId { get; set; }
        [Column("PedVrUnit", TypeName = "money")]
        public decimal UnitValue { get; set; }
        [Column("PedCant")]
        public float Amount { get; set; }
        [Column("PedSubTot", TypeName = "money")]
        public decimal SubTotal { get; set; }
        [Column("PedIVA")]
        public float IVA { get; set; }
        [Column("PedTotal", TypeName = "money")]
        public decimal Total { get; set; }
    }
}
