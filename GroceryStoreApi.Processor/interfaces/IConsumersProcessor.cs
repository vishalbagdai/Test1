using GroceryStoreApi.Model.request;
using GroceryStoreApi.Model.response;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStoreApi.Processor.interfaces
{
    public interface IConsumersProcessor
    {
        Task<int> Create(CustomerRequest customer);
        Task<IEnumerable<CustomerResponse>> GetAll(string search);
        Task<CustomerResponse> Get(int id);
        Task<int> Update(int id, CustomerRequest  customer);
        Task<int> Delete(int id);

    }
}
