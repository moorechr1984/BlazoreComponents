using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorComponentPOC.Data
{
    public class StoreOrderService
    {
        private List<ProductListRow> _cache = new List<ProductListRow>();
        private List<DFInformationRow> _dfInformationCache = new List<DFInformationRow>();
        public Task<List<ProductListRow>> GetProductListRows()
        {
            for(int i=0; i<=25; i++)
            {
                _cache.Add(new ProductListRow
                {
                    OrderDate = DateTime.Now,
                    ProductId = 519933,
                    BalanceOnHand = i,
                    CasepackFlag = "Y",
                    DfToDFTransferQuantity = 234,
                    ItemStatus = "TEST",
                    MeijerItemCode = "202252",
                    PackQuantity = 12,
                    ProductDescription = "Bananas",
                    PromoStoreNumber = i,
                    PromotionType = "Promo Type"

                });
            }
            return Task.FromResult(_cache);
        }

        public Task<List<DFInformationRow>> GetDFInformationRows(ProductListRow row)
        {
            _dfInformationCache.Clear();
            for (int i = 0; i <= 3; i++)
            {
                _dfInformationCache.Add(new DFInformationRow
                {
                    BalanceOnHand = 42,
                    CodeDate = DateTime.Now,
                    DFId = 85, 
                    DfToDFTransferQuantity = 0,
                    FuturePODate = DateTime.Now.AddDays(1),
                    FuturePOId = 1232,
                    FuturePOQuantity = 42, 
                    NetQuantity = 10,
                    OOSSub = 0,
                    OvrSub = 0,
                    PMMTransferQuantity = 0, 
                    PurchaseOrderQuantity = 10,
                    TotalAdjustedQuantity = 500,
                    TotalAvailableQuantity = 5,                    

                });
            }
            return Task.FromResult(_dfInformationCache);
        }

        public void AddRow()
        {
            //int lastIndex = _cache.Count() - 1;
            //_cache.Insert(lastIndex + 1, new StoreOrder());
        }
    }
}
