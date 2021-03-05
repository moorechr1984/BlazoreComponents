using BlazorComponentPOC.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorComponentPOC.Data
{
    public class DFInformationRow
    {
        [Column("DF", 1)]
        public int DFId { get; set; }
        [Column("BOH", 2)]
        public int BalanceOnHand { get; set; }
        [Column("PO", 3)]
        public int PurchaseOrderQuantity { get; set; }

        [Column("PO Received Qty", 4)]
        public int PurchaseOrderrReceivedQuantity { get; set; }
        [Column("DF-DF", 5)]
        public int DfToDFTransferQuantity { get; set; }
        [Column("Yesterday Frozen Open Ord", 6)]
        public int YesterdayFrozenOrderQuantity { get; set; }
        [Column("Total Avail", 7)]
        public int TotalAvailableQuantity { get; set; }
        [Column("TOQ", 8)]
        public int TotalOrderQuantity { get; set; }
        [Column("TALQ", 9)]
        public int TotalAutoLeveledQuantity { get; set; }
        [Column("TAQ", 10)]
        public int TotalAdjustedQuantity { get; set; }
        [Column("TSQ", 11)]
        public int TotalStoreQuantity { get; set; }
        [Column("PMM xfr Qty", 12)]
        public int PMMTransferQuantity { get; set; }
        [Column("Total Demand", 13)]
        public int TotalDemand { get; set; }
        [Column("Net Quantity", 14)]
        public int NetQuantity { get; set; }
        [Column("Future PO Date", 15)]
        public DateTime FuturePODate { get; set; }
        [Column("Future PO Quantity", 16)]
        public int FuturePOQuantity { get; set; }
        [Column("Future PO ID", 17)]
        public int FuturePOId { get; set; }
        [Column("Code Date", 18)]
        public DateTime CodeDate { get; set; }
        [Column("OVR Sub", 19)]
        public int OvrSub { get; set; }
        [Column("OOS Sub", 20)]
        public int OOSSub { get; set; }
    }
}
