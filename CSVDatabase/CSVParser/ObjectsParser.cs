using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSVDatabase.CSVParser {
    public static class ObjectsParser {

        public static string Serialize<T>( T obj )
                where T : ISerialized {
            return obj.ToCSV();
        }

        public static string SerializeMany<T>( List<T> objectList )
                where T : ISerialized {
            string outputString = "";
            foreach (T obj in objectList) {
                outputString += obj.ToCSV() + "\n";
            }
            return outputString;
        }

        public static T Deserialize<T>( string objStreamData )
                where T : new() {
            return ObjectFactory.CreateObjectFromString<T>(objStreamData);
        }

        public static List<T> DeserializeMany<T>( string objStreamData )
                where T : new() {
            List<string> objectDataList = objStreamData.Split("\n").ToList();
            List<T> objectsList = new List<T>();
            foreach (string objectData in objectDataList) {
                T newObject = ObjectFactory.CreateObjectFromString<T>(objectData);
                objectsList.Add(newObject);
            }
            return objectsList;
        }

    }
}
