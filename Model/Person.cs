using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Zipcode { get; set; }

        public string City { get; set; }

        public string Color { get; set; }


        public static Person personValues(string strCsv)
        {
            string[] values = strCsv.Split(',');
            Person person = new Person();
            person.Id = Convert.ToInt32(values[0]);
            person.Name = values[1];
            person.Lastname = values[2];
            person.Zipcode = values[3];
            person.City = values[4];
            person.Color = values[5];
            return person;
        }
    }
}
