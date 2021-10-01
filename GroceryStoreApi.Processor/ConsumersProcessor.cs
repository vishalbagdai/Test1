using AutoMapper;
using GroceryStoreApi.Engine.interfaces;
using GroceryStoreApi.Entity;
using GroceryStoreApi.Model.request;
using GroceryStoreApi.Model.response;

using GroceryStoreApi.Processor.interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroceryStoreApi.Processor
{
    public class ConsumersProcessor : IConsumersProcessor
    {
        public readonly IConsumersEngine _consumersEngine;
        public readonly IMapper _mapper;
        public ConsumersProcessor(IConsumersEngine consumersEngine, IMapper mapper)
        {
            _consumersEngine = consumersEngine;
            _mapper = mapper;
        }
        public async Task<int> Create(CustomerRequest customer)
        {
            return await _consumersEngine.Create(_mapper.Map<CustomerEntity>(customer));
        }
        public async Task<IEnumerable<CustomerResponse>> GetAll(string search)
        {
            return _mapper.Map<List<CustomerResponse>>(await _consumersEngine.GetAll(search));
        }
        public async Task<CustomerResponse> Get(int id)
        {
            return _mapper.Map<CustomerResponse>(await _consumersEngine.Get(id));
        }
        public async Task<int> Update(int id, CustomerRequest customer)
        {
            return await _consumersEngine.Update(id, _mapper.Map<CustomerEntity>(customer));
        }
        public async Task<int> Delete(int id)
        {
            return await _consumersEngine.Delete(id);
        }
    }
}
