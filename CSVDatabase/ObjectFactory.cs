using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSVDatabase {

    public static class ObjectFactory {

        public static T CreateObjectFromString<T>( string dataStream )
            where T : new() {
            T obj = new T();

            List<string> values = dataStream.Split(",").ToList();
            int parsedPropertyAmount = PropertyExtension.GetPropertiesAmount(obj);
            List<string> propertyNames = PropertyExtension.GetPropertyNamesList(obj);

            if (values.Count() != parsedPropertyAmount) {
                throw new InvalidCastException($"Expected properties in data stream: {parsedPropertyAmount}, while given {values.Count()}");
            } else {
                for (int propertyId = 0; propertyId < parsedPropertyAmount; propertyId++) {
                    PropertyExtension.SetPropertyValue(obj, propertyNames[propertyId], values[propertyId]);
                }
            }
            return obj;
        }

        public static List<T> GetObjectsFromFile<T>( string filepath )
            where T : new() {
            throw new NotImplementedException();
        }

    }

}
