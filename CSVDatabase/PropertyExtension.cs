using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSVDatabase {
    public static class PropertyExtension {

        public static void SetPropertyValue( this object obj, string propName, object value ) {
            if (obj.GetType().GetProperty(propName).CanWrite) {
                Type propertyType = obj.GetType().GetProperty(propName).PropertyType;
                dynamic castedValue;
                if (propertyType == typeof(Guid)) {
                    castedValue = Guid.Parse(value.ToString().ToCharArray());
                } else {
                    castedValue = Convert.ChangeType(value, propertyType);
                }
                obj.GetType().GetProperty(propName).SetValue(obj, castedValue, null);
            }
        }

        public static List<string> GetPropertyNamesList( this object obj ) {
            List<string> propertyList = new List<string>();
            foreach (var prop in obj.GetType().GetProperties()) {
                propertyList.Add(prop.Name);
            }
            return propertyList;
        }

        public static int GetPropertiesAmount( this object obj ) {
            return obj.GetType().GetProperties().Count();
        }

    }

}
