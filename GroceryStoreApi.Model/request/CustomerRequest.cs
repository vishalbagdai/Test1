using System;
using System.ComponentModel.DataAnnotations;

namespace GroceryStoreApi.Model.request
{
    public class CustomerRequest
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
