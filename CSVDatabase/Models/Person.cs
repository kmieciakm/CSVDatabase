using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSVDatabase.CSVParser;

namespace CSVDatabase.Models {
    public class Person : ISerialized {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int PhoneNumber { get; private set; }
        
        public string ToCSV() {
            return  Id.ToString() + "," + FirstName + "," + LastName + "," + PhoneNumber;
        }

        public string GetFullName() {
            return FirstName + " " + LastName; 
        }

        public Person( string firstname, string lastname, int phone ) : this(firstname, lastname) {
            PhoneNumber = phone;
        }

        public Person( string firstname, string lastname ) : this() {
            FirstName = firstname;
            LastName = lastname;
        }

        public Person() {
            Id = Guid.NewGuid();
            FirstName = "";
            LastName = "";
            PhoneNumber = default;
        }
    }

}
