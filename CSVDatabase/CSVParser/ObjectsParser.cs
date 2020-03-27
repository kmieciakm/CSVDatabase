using System;
using System.Collections.Generic;
using System.Text;

namespace CSVDatabase.CSVParser {
    public static class ObjectsParser {

        public static string Serialize<T>( T obj )
                where T : ISerialized {
            return obj.ToCSV();
        }

        public static T Deserialize<T>( string stream )
                where T : new() {
            return ObjectFactory.CreateObjectFromString<T>(stream);
        }

    }
}
