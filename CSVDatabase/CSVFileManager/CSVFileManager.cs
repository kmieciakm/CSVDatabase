using CSVDatabase.CSVParser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSVDatabase.CSVFileManager {

    public static class FileManager {

        public static List<T> ReadFile<T>( string filepath )
                where T : new() {
            string dataString;
            if (File.Exists(filepath)) {
                dataString = File.ReadAllText(filepath);
            } else {
                throw new ArgumentException($"File {filepath} does not exist");
            }

            return ObjectsParser.DeserializeMany<T>(dataString);
        }

        public static void WriteFile<T>( string filepath, List<T> objectsList )
                where T : ISerialized, new() {
            string outputData = ObjectsParser.SerializeMany(objectsList);
            File.WriteAllText(filepath, outputData);
        }

    }

}
