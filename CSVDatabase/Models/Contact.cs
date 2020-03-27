using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSVDatabase.CSVParser;

namespace CSVDatabase.Models {
    public class Address : ISerialized {
        public Guid Id { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string Street { get; private set; }
        public int HomeNumber { get; private set; }

        public string ToCSV() {
            return Id.ToString() + "," + City + "," + PostalCode + "," + Street + "," + HomeNumber;
        }

        public Address(string city, string postalCode, string street, int homeNumber) {
            City = city;
            PostalCode = postalCode;
            Street = street;
            HomeNumber = homeNumber;
        }

        public Address() {
            Id = Guid.NewGuid();
            City = "";
            PostalCode = "";
            Street = "";
            HomeNumber = default;
        } 
    }
}
