using Microsoft.Extensions.Configuration;
using Model;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace DataAccessCsvProvider
{
    public class DaCsvProvider : IDataAccessProvider
    {

        private readonly DomainModelCsvContext _context;
        public string path;

        public DaCsvProvider(DomainModelCsvContext context)
        {
            _context = context;
            var config = new ConfigurationBuilder()
                   .AddJsonFile("appsettings.json")
                   .Build();
            path = config["CsvPath"];
        }
        public List<Person> ReadCSV()
        {
            
            List<Person> person = File.ReadAllLines(path)
                                          .Skip(1)                                          
                                          .Select(v => Person.personValues(v))
                                          .ToList();            
            return person;
        }

        public List<Person> ReadCSVById(int Id)
        {
            List<Person> person = File.ReadAllLines(path)
                                          .Skip(1)
                                          .Select(v => Person.personValues(v))                                         
                                          .ToList();
            person = person.Where(x => x.Id.Equals(Id)).ToList();
            return person;
        }

        public List<Person> ReadCSVByColour(string color)
        {
            List<Person> person = File.ReadAllLines(path)
                                          .Skip(1)
                                          .Select(v => Person.personValues(v))
                                          .ToList();
            person = person.Where(x => x.Color.ToLower().Equals(color.ToLower())).ToList();
            return person;
        }
    }
}
