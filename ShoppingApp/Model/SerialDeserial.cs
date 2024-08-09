using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ShoppingApp.Model
{
    public class SerialDeserial
    {
        public static void Serialization(Person person)
        {
            File.WriteAllText("Person.json",JsonConvert.SerializeObject(person));
        }

        public static Person Deserialization()
        {
            Person person = new Person();
            string fileName = "Person.json";
            if (File.Exists(fileName)) 
            { 
                string json = File.ReadAllText(fileName);
                person = JsonConvert.DeserializeObject<Person>(json);
            }
            return person;

        }
    }
}
