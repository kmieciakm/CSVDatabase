using System;
using Xunit;
using CSVDatabase.CSVParser;
using CSVDatabase.Models;
using System.Collections.Generic;

namespace XUnitTests {

    public class ObjectParserTests {

        [Fact]
        public void ObjectParser_AssertTrue_TestPassed() {
            Assert.True(true);
        }

        [Fact]
        public void ObjectParser_SeriazlizePersonObject_StringCorrect() {
            Person person = new Person("Mateusz", "Kmieciak", 788088055);
            string expectedString = person.Id + ",Mateusz,Kmieciak,788088055";
            Assert.Equal(expectedString, ObjectsParser.Serialize(person));
        }

        [Fact]
        public void ObjectParser_SeriazlizeInitialAddressObject_StringCorrect() {
            Address address = new Address();
            string expectedString = address.Id + ",,,,0";
            Assert.Equal(expectedString, ObjectsParser.Serialize(address));
        }

        [Fact]
        public void ObjectParser_SeriazlizeManyAddresses_StringCorrect() {
            Address addressOne = new Address("Lodz", "91-322", "Rozana", 12);
            Address addressTwo = new Address("Krakow", "04-218", "Niepokonanych", 14);
            string expectedString = addressOne.Id + ",Lodz,91-322,Rozana,12" + "\n" +
                                    addressTwo.Id + ",Krakow,04-218,Niepokonanych,14";
            List<Address> addresses = new List<Address> { addressOne, addressTwo };
            Assert.Equal(expectedString, ObjectsParser.SerializeMany(addresses));
        }

        [Fact]
        public void ObjectParser_DeseriazlizePersonData_ObjectFullNameCorrect() {
            string dataString = "00000000-0000-0000-0000-000000000001,Mateusz,Kmieciak,0";
            Person person = ObjectsParser.Deserialize<Person>(dataString);
            string expectedFullName = "Mateusz Kmieciak";
            Assert.Equal(expectedFullName, person.GetFullName());
        }

        [Fact]
        public void ObjectParser_DeseriazlizeWrongPersonData_ThrowExecption() {
            string dataString = "00000000-0000-0000-0000-000000000001,Kmieciak,0";
            Assert.Throws<InvalidCastException>(() => ObjectsParser.Deserialize<Person>(dataString));
        }

        [Fact]
        public void ObjectParser_DeseriazlizeContactData_ObjectPropertiesCorrect() {
            string dataString = "00000000-0000-0000-0000-000000000001,Lodz,91-321,Sedziowska,9";
            Address address = ObjectsParser.Deserialize<Address>(dataString);
            Assert.Equal("Lodz", address.City);
            Assert.Equal("91-321", address.PostalCode);
            Assert.Equal("Sedziowska", address.Street);
            Assert.Equal(9, address.HomeNumber);
        }

        [Fact]
        public void ObjectParser_DeseriazlizeManyObjects_ObjectsDataCorrect() {
            string dataString = "00000000-0000-0000-0000-000000000001,Mario,Bros,013091985" + "\n" +
                                "00000000-0000-0000-0000-000000000002,Mario2,Bros2,113091985";
            List<Person> personList = ObjectsParser.DeserializeMany<Person>(dataString);
            string expectedFullNameFirst = "Mario Bros";
            string expectedFullNameSecond = "Mario2 Bros2";
            Assert.Equal(expectedFullNameFirst, personList[0].GetFullName());
            Assert.Equal(expectedFullNameSecond, personList[1].GetFullName());
        }

        [Fact]
        public void ObjectParser_DeseriazlizeManyWrongData_ThrowExecption() {
            string dataString = "00000000-0000-0000-0000-000000000001,Kmieciak" + "\n" +
                                "00000000-0000-0000-0000-000000000002,Mario,Bros,013091985";
            Assert.Throws<InvalidCastException>(() => ObjectsParser.Deserialize<Person>(dataString));
        }

    }

}
