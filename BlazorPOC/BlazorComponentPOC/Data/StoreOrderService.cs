using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorComponentPOC.Data
{
    public class StoreOrderService
    {
        private List<ProductListRow> _cache = new List<ProductListRow>();
        public Task<List<ProductListRow>> GetStoreOrders()
        {
            for(int i=0; i<=25; i++)
            {
                _cache.Add(new ProductListRow
                {
                    UnitId = 42,
                    OrderDate = DateTime.Now,
                    ProductId = 519933,
                    BalanceOnHand = 300,
                    CasepackFlag = "Y",
                    DfToDFTransferQuantity = 234,
                    ItemStatus = "TEST",
                    MeijerItemCode = "202252",
                    PackQuantity = 12,
                    ProductDescription = "Bananas",
                    PromoStoreNumber = 163,
                    PromotionType = "Promo Type"

                });
            }
            return Task.FromResult(_cache);
        }

        public void AddRow()
        {
            //int lastIndex = _cache.Count() - 1;
            //_cache.Insert(lastIndex + 1, new StoreOrder());
        }
    }
}
