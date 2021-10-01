using GroceryStoreApi.Model.request;
using GroceryStoreApi.Model.response;
using GroceryStoreApi.Processor;
using GroceryStoreApi.Processor.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : BaseApiController
    {
        public readonly IConsumersProcessor _consumersProcessor;
        public CustomersController(IConsumersProcessor consumersProcessor)
        {
            _consumersProcessor = consumersProcessor;
        }

        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [HttpPost]
        public async Task<IActionResult> Create(CustomerRequest customer)
        {
            return Ok(await _consumersProcessor.Create(customer));
        }

        [ProducesResponseType(typeof(List<CustomerResponse>), (int)HttpStatusCode.OK)]
        [HttpGet]
        public async Task<IActionResult> GetAll(string search)
        {
            return Ok(await _consumersProcessor.GetAll(search));
        }
        [ProducesResponseType(typeof(CustomerResponse), (int)HttpStatusCode.OK)]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return Ok(await _consumersProcessor.Get(id));
        }
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, CustomerRequest customer)
        {
            return Ok(await _consumersProcessor.Update(id, customer));
        }
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _consumersProcessor.Delete(id));
        }
    }
}
