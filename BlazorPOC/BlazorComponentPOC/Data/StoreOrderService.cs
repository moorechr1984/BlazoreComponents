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
                _cache.Add(new ProductListRow
                {
                    ProductId = 519933,
                    ProductDescription = "BANANAS LB",
                    MeijerItemCode = "189386",
                    BalanceOnHand = 2130,
                    PurchaseOrderQuantity = 348,
                    TotalAvailableQuantity = 2478,
                    CasepackFlag = "N",
                    ItemStatus = "STO",
                    PackQuantity = 40

                });
                _cache.Add(new ProductListRow
                {
                    ProductId = 519933,
                    ProductDescription = "BANANAS LB",
                    MeijerItemCode = "202004",
                    ItemStatus = "STO",
                    PackQuantity = 40,

                });
                _cache.Add(new ProductListRow
                {
                    ProductId = 519933,
                    ProductDescription = "BANANAS LB",
                    MeijerItemCode = "202525",
                    BalanceOnHand = 5586,
                    PurchaseOrderQuantity = 894,
                    TotalAvailableQuantity = 6480,
                    CasepackFlag = "Y",
                    ItemStatus = "STO",
                    PackQuantity = 40,

                });
            return Task.FromResult(_cache);
        }

        public Task<List<DFInformationRow>> GetDFInformationRows(ProductListRow row)
        {
            var list = new List<DFInformationRow>();
            list.Add(new DFInformationRow
            {
                DFId = 85,
                BalanceOnHand = 804,
                TotalAvailableQuantity = 804,
                NetQuantity = 804                   

            });
            list.Add(new DFInformationRow
            {
                DFId = 85,
                BalanceOnHand = 498,
                TotalAvailableQuantity = 498,
                NetQuantity = 498
            });
            list.Add(new DFInformationRow
            {
                DFId = 872,
                BalanceOnHand = 318,
                PurchaseOrderQuantity = 348,
                TotalAvailableQuantity = 667,
                NetQuantity = 667
            });
            list.Add(new DFInformationRow
            {
                DFId = 883,
                BalanceOnHand = 510,
                TotalAvailableQuantity = 510,
                NetQuantity = 510
            });
            return Task.FromResult(list);
        }

        public void AddRow()
        {
            //int lastIndex = _cache.Count() - 1;
            //_cache.Insert(lastIndex + 1, new StoreOrder());
        }
    }
}
