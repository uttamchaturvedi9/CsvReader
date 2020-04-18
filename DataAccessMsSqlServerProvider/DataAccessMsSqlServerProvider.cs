using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessMsSqlServerProvider
{
    public class DataAccessMsSqlServerProvider : IDataAccessProvider
    {
        public List<Person> ReadCSV()
        {
            throw new NotImplementedException();
        }

        public List<Person> ReadCSVByColour(string color)
        {
            throw new NotImplementedException();
        }

        public List<Person> ReadCSVById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
