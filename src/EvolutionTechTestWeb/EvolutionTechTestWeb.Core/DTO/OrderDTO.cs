using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionTechTestWeb.Core.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public int OrderUserId { get; set; }

        public int OrderProductId { get; set; }

        public decimal UnitValue { get; set; }

        public float Amount { get; set; }

        public decimal SubTotal { get; set; }

        public float IVA { get; set; }

        public decimal Total { get; set; }
    }
}
