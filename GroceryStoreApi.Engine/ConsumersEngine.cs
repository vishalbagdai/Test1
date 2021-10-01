using GroceryStoreApi.Engine.interfaces;
using GroceryStoreApi.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using GroceryStoreAPI.ExceptionHandler;

namespace GroceryStoreApi.Engine
{
    public class ConsumersEngine : IConsumersEngine
    {
        DatabaseContext dbContext;
        public ConsumersEngine()
        {
            dbContext = new DatabaseContext();
        }
        public async Task<int> Create(CustomerEntity customer)
        {
            //generate and get incremental id
            customer.Id = dbContext.getNewId();

            /* Customer can have same name so i haven't implemented validation for already exists */
            dbContext.data.Customers.Add(customer);
            return await Task.FromResult(dbContext.saveChanges() ? customer.Id : 0);
        }
        public async Task<IEnumerable<CustomerEntity>> GetAll(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                return await Task.FromResult(dbContext.data.Customers.Where(x => x.Name.ToLower().Contains(search.Trim().ToLower())));
            }
            return await Task.FromResult(dbContext.data.Customers);
        }
        public async Task<CustomerEntity> Get(int id)
        {
            var customer = dbContext.data.Customers.FirstOrDefault(x => x.Id == id);
            if (customer != null)
            {
                return await Task.FromResult(customer);
            }
            throw new NotFoundCustomException(ErrorMessages.Error001);
        }
        public async Task<int> Update(int id, CustomerEntity customer)
        {
            var existinCustomer = await Get(id);
            existinCustomer.Name = customer.Name;
            return await Task.FromResult(dbContext.saveChanges() ? 1 : 0);
        }
        public async Task<int> Delete(int id)
        {
            var existinCustomer = await Get(id);
            dbContext.data.Customers.Remove(existinCustomer);
            return await Task.FromResult(dbContext.saveChanges() ? 1 : 0);
        }
    }
}

