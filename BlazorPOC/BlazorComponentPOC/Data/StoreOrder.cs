using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorComponentPOC.Data
{
    public class StoreOrder
    {

        [Components.Column("Order Date", 1)]
        public DateTime? OrderDate { get; set; }

        [Components.Column("Store #", 2)]
        public int? UnitId { get; set; }


        [Components.Column("Pid", 3)]
        public int ProductId { get; set; }

        [Components.Column("Quantity", 4)]
        public int? RequestedQuantity { get; set; }

        [Components.Column("Id", 5)]
        public Guid Id { get { return Guid.NewGuid(); } }

    }
}
