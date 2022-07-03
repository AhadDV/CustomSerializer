using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Task.service.Implementations
{
   public class DeSerializerService:CustomSerializeService
    {
        public static T DeSerialize<T>(string serializeData, T target) where T : new()
        {
            var deserializedObjects = Extract(serializeData);

            foreach (var obj in deserializedObjects)
            {
                var properties = ExtractValuesFromData(obj);
                foreach (var item in properties)
                {
                    
                    var propInfo = target.GetType().GetProperty(item.PropertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                    propInfo?.SetValue(target,
                    Convert.ChangeType(item.Value, propInfo.PropertyType), null);
                }
            }
            return target;
        }
    }
}
