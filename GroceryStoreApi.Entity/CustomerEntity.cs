using System;
using System.Text.Json.Serialization;

namespace GroceryStoreApi.Entity
{
    public class CustomerEntity
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
