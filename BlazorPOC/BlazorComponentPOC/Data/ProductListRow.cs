using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorComponentPOC.Data
{
    public class ProductListRow
    {

        [Components.Column("Pid", 1)]
        public int ProductId { get; set; }

        [Components.Column("Product Description", 2)]
        public string ProductDescription{ get; set; }

        [Components.Column("MIC", 3)]
        public string MeijerItemCode { get; set; }

        [Components.Column("BOH", 4)]
        public int BalanceOnHand { get; set; }

        [Components.Column("PO", 5)]
        public int PurchaseOrderQuantity { get; set; }

        [Components.Column("DF-DF", 6)]
        public int DfToDFTransferQuantity { get; set; }

        [Components.Column("Total Avail", 7)]
        public int TotalAvailableQuantity { get; set; }

        [Components.Column("TOQ", 8)]
        public int TotalOrderQuantity { get; set; }

        [Components.Column("TSQ", 9)]
        public int TotalStoreOrderQuantity { get; set; }

        [Components.Column("CPK Flag", 10)]
        public string CasepackFlag { get; set; }

        [Components.Column("ItemStatus", 11)]
        public string ItemStatus { get; set; }

        [Components.Column("Pack QTY", 12)]
        public decimal PackQuantity { get; set; }

        [Components.Column("Promo Type", 13)]
        public string PromotionType { get; set; }

        [Components.Column("Promo Store #", 14)]
        public int PromoStoreNumber { get; set; }





        //[Components.Column("Id", 16)]
        //public Guid Id { get { return Guid.NewGuid(); } }

    }
}
