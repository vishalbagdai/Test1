using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using GroceryStoreApi.Entity;
using GroceryStoreApi.Model.request;
using GroceryStoreApi.Model.response;

namespace GroceryStoreApi.Processor.mapper
{
    public class ConsumerMapperProfile : Profile
    {
        public ConsumerMapperProfile()
        {
            CreateMap<CustomerEntity, CustomerRequest>().ReverseMap();
            CreateMap<CustomerResponse, CustomerEntity>().ReverseMap();
        }
    }
}
