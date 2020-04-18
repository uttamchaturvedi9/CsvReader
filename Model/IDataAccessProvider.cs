using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public interface IDataAccessProvider
    {
        List<Person> ReadCSV();
        List<Person> ReadCSVById(int Id);
        List<Person> ReadCSVByColour(string color);
    }
}
