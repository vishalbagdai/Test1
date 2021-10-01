using GroceryStoreApi.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStoreApi.Engine.interfaces
{
    public interface IConsumersEngine
    {
        Task<int> Create(CustomerEntity customer);
        Task<IEnumerable<CustomerEntity>> GetAll(string search);
        Task<CustomerEntity> Get(int id);
        Task<int> Update(int id, CustomerEntity customer);
        Task<int> Delete(int id);
    }
}
