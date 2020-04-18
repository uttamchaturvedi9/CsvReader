using Autofac.Extras.Moq;
using DataAccessCsvProvider;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AssecorTest
{
    public class AcessorUnitTest
    {

        [Fact]
        public void LoadPerson_ValidCall()
        {

            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IDataAccessProvider>()
                    .Setup(x => x.ReadCSV())
                    .Returns(GetSamplePerson());

                var cls = mock.Create<DaCsvProvider>();
                var expected = GetSamplePerson();

                var actual = cls.ReadCSV();

                Assert.True(actual!= null);
                Assert.Equal(expected.Count, actual.Count);


                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.Equal(expected[i].Name, actual[i].Name.Trim());
                    Assert.Equal(expected[i].Lastname, actual[i].Lastname.Trim());
                }
            }

        }

        [Fact]
        public void LoadPerson_ById_ValidCall()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IDataAccessProvider>()
                    .Setup(x => x.ReadCSVById(1))
                    .Returns(GetSinglePerson());

                var cls = mock.Create<DaCsvProvider>();
                var expected = GetSinglePerson();

                var actual = cls.ReadCSVById(1);

                Assert.True(actual != null);
                Assert.Equal(expected.Count, actual.Count);

                Assert.Equal(expected[0].Name, actual[0].Name.Trim());
                Assert.Equal(expected[0].Lastname, actual[0].Lastname.Trim());
            }

        }

        [Fact]
        public void LoadPerson_ByColor_ValidCall()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IDataAccessProvider>()
                    .Setup(x => x.ReadCSVByColour("Red"))
                    .Returns(GetSinglePerson());

                var cls = mock.Create<DaCsvProvider>();
                var expected = GetSinglePerson_ByColor();

                var actual = cls.ReadCSVByColour("Red");

                Assert.True(actual != null);
                Assert.Equal(expected.Count, actual.Count);

                Assert.Equal(expected[0].Name, actual[0].Name.Trim());
                Assert.Equal(expected[0].Lastname, actual[0].Lastname.Trim());
            }

        }

        public List<Person>  GetSamplePerson()
        {
            List<Person> output = new List<Person>
            {                
                   new Person
                   {
                       Id = 1,
                       Name = "Hans",
                       Lastname= "Muller",
                       City = "Jaipur",
                       Color = "Lemon",
                       Zipcode = "67742"

                   },
                   new Person
                   {
                       Id = 2,
                       Name = "Peter",
                       Lastname= "Petersen",
                       City = "Stralsund",
                       Color = "Green",
                       Zipcode = "18439"
                   },
                   new Person
                   {
                       Id = 3,
                       Name = "Johnny",
                       Lastname= "Johnson",
                       City = "New York",
                       Color = "Yellow",
                       Zipcode = "3565"

                   },
                   new Person
                   {
                       Id = 4,
                       Name = "Milly",
                       Lastname= "Millenium",
                       City = "Atlanta",
                       Color = "Blue",
                       Zipcode = "456577"

                   },
                   new Person
                   {
                       Id = 5,
                       Name = "Jonas",
                       Lastname= "Muller",
                       City = "Califirnia",
                       Color = "Red",
                       Zipcode = "45674"

                   }
            };
            return output;
        }

        public List<Person> GetSinglePerson()
        {
            List<Person> output = new List<Person>
            {
                   new Person
                   {
                       Id = 1,
                       Name = "Hans",
                       Lastname= "Muller",
                       City = "Jaipur",
                       Color = "Lemon",
                       Zipcode = "67742"

                   }
            };
            return output;
        }

        public List<Person> GetSinglePerson_ByColor()
        {
            List<Person> output = new List<Person>
            {                 
                   new Person
                   {
                       Id = 5,
                       Name = "Jonas",
                       Lastname= "Muller",
                       City = "Califirnia",
                       Color = "Red",
                       Zipcode = "45674"

                   }
            };
            return output;
        }

    }
}
