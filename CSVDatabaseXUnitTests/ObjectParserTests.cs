using System;
using Xunit;
using CSVDatabase.CSVParser;
using CSVDatabase.Models;

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

    }

}
