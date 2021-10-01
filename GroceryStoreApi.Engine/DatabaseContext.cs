using GroceryStoreApi.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using GroceryStoreAPI.ExceptionHandler;

namespace GroceryStoreApi.Engine
{
    public class DatabaseContext
    {
        readonly string FilePath = Path.Combine(Directory.GetCurrentDirectory(), $"database.json");
        public DataFile data { get; set; }

        public DatabaseContext()
        {
            setupDataFile();
        }
        public int getNewId()
        {
            var cust = data.Customers.LastOrDefault();
            if (cust != null)
            {
                return cust.Id + 1;
            }
            return 1;
        }

        public void setupDataFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(FilePath))
                {
                    string json = sr.ReadToEnd();
                    data = JsonConvert.DeserializeObject<DataFile>(json);
                    if (data == null)
                    {
                        data = new DataFile() { Customers = new List<CustomerEntity>() };
                    }
                }
            }
            catch (Exception)
            {
                //log error here into file or database etc..
                throw new DefaultInternalServerErorr(ErrorMessages.Error002);
            }

        }
        public bool saveChanges()
        {
            try
            {
                File.WriteAllText(FilePath, JsonConvert.SerializeObject(data));
                return true;
            }
            catch (Exception)
            {
                //log error here into file or database etc..
                throw new DefaultInternalServerErorr(ErrorMessages.Error002);
            }
        }
    }
}
