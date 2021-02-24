using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorComponentPOC.Data
{
    public class StoreOrderService
    {
        private List<StoreOrder> _cache = new List<StoreOrder>
        {
            new StoreOrder
            {
                UnitId = 42,
                OrderDate = DateTime.Now,
                ProductId = 519933,
                RequestedQuantity = 1
            }
        };

        public Task<List<StoreOrder>> GeStoreOrders()
        {
            for(int i=0; i<=100; i++)
            {
                _cache.Add(new StoreOrder
                {
                    UnitId = i,
                    OrderDate = DateTime.Now,
                    ProductId = 519933,
                    RequestedQuantity = 1 + i
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
