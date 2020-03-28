using CSVDatabase.Models;
using CSVDatabase.CSVParser;
using CSVDatabase.CSVFileManager;
using System;
using System.Collections.Generic;

namespace CSVDatabase {
    class Program {
        static void Main( string[] args ) {
            string usersFilepath = "C:\\Temp\\users.csv";

            try {
                List<Person> personList = FileManager.ReadFile<Person>(usersFilepath);

                foreach (var person in personList) {
                    Console.WriteLine(person.GetFullName());
                }
            } catch (ArgumentException e) {
                Console.WriteLine( e.Message );
            }

            List<Address> addresses = new List<Address> {
                new Address("Lodz", "91-322", "Rozana", 12),
                new Address("Krakow", "04-218", "Niepokonanych", 14)
            };

            string addressesFilepath = "C:\\Temp\\addresses.csv";
            FileManager.WriteFile(addressesFilepath, addresses);
        }
    }
}
