using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorComponentPOC.Data
{
    public class ProductListRow
    {

        [Components.Column("Order Date", 1)]
        public DateTime? OrderDate { get; set; }

        [Components.Column("Pid", 2)]
        public int ProductId { get; set; }

        [Components.Column("Product Description", 3)]
        public string ProductDescription{ get; set; }

        [Components.Column("MIC", 4)]
        public string MeijerItemCode { get; set; }

        [Components.Column("BOH", 5)]
        public int BalanceOnHand { get; set; }

        [Components.Column("PO", 6)]
        public int PurchaseOrderQuantity { get; set; }

        [Components.Column("DF-DF", 7)]
        public int DfToDFTransferQuantity { get; set; }

        [Components.Column("Total Avail", 8)]
        public int TotalAvailableQuantity { get; set; }

        [Components.Column("TOQ", 9)]
        public int TotalOrderQuantity { get; set; }

        [Components.Column("TSQ", 10)]
        public int TotalStoreOrderQuantity { get; set; }

        [Components.Column("CPK Flag", 11)]
        public string CasepackFlag { get; set; }

        [Components.Column("ItemStatus", 12)]
        public string ItemStatus { get; set; }

        [Components.Column("Pack QTY", 13)]
        public int PackQuantity { get; set; }

        [Components.Column("Promo Type", 14)]
        public string PromotionType { get; set; }

        [Components.Column("Promo Store #", 15)]
        public int PromoStoreNumber { get; set; }





        [Components.Column("Id", 16)]
        public Guid Id { get { return Guid.NewGuid(); } }

    }
}
