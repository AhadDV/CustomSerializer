using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Task.service.InterFaces;

namespace Task.service.Implementations
{
    public class CustomSerializeService 
    {
      
        public static string Serialize(object obj)
        {
            var sb = new StringBuilder();
            sb.AppendLine();
            sb.Append("{");
            var Type = obj.GetType();
            IList<PropertyInfo> propsss = new List<PropertyInfo>(Type.GetProperties());
            foreach (var item in propsss)
            {
                var propValue = item.GetValue(obj, null);
                sb.AppendLine();
                sb.Append(@"[" + item.Name + "=" + propValue + "]");
            }
            sb.AppendLine();
            sb.Append("}");
            return sb.ToString();
        }

        public static List<string> Extract(string text, string startString = "{", string endString = "}")
        {
            if (text.Contains("\n"))
                text = text.Replace("\n", string.Empty);

            if (text.Contains("\t"))
               text= text.Replace("\t", string.Empty);

            var contest = new List<string>();
            var exit = false;
            while (!exit)
            {
                var indexStart = text.IndexOf(startString, StringComparison.Ordinal);
                var indexEnd = text.LastIndexOf(endString);
                if (indexStart != -1 && indexEnd != -1)
                {
                        contest.Add(text.Substring(indexStart + startString.Length,
                            indexEnd - indexStart - startString.Length));
                    text = text.Substring(indexEnd + endString.Length);
                }
                else
                {
                    exit = true;
                }
            }
            return contest;
        }

        public static List<Task.core.Entities.Data> ExtractValuesFromData(string text)
        {
            var listMyData = new List<Task.core.Entities.Data>();
            text=  String.Concat(text.Where(c => !Char.IsWhiteSpace(c)));
            var index = text.IndexOf(":{");
             if (index!=-1)
            {

            int nearest = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ',')
                {
                    int CommaIndex = index - i;
                    if (CommaIndex>0)
                        nearest = i;
                    else
                        break;
                }
            }
            string text1 = text.Substring(0, nearest);
            string text2 = text.Remove(0,nearest+1);
            string[] arr = new string[2];
            arr[0] = text1;
            arr[1] = text2;
            var firstdata = arr[0].Split(",");
           
            var secondsata = Extract(arr[1], "{", "}");
            var seconddataa = secondsata[0].Split(',');

            foreach (var item in firstdata)
            {
                
                var pName = item.Substring(0, item.IndexOf(":", StringComparison.Ordinal));
                var pValue = item.Substring(item.IndexOf(":", StringComparison.Ordinal) + 1);
                listMyData.Add(new Task.core.Entities.Data { PropertyName = pName, Value = pValue });
            }
            foreach (var item in seconddataa)
            {
                if (item.Contains(":"))
                {
                    var pName = item.Substring(0, item.IndexOf(":", StringComparison.Ordinal)).ToLower();
                    var pValue = item.Substring(item.IndexOf(":", StringComparison.Ordinal) + 1).ToLower();
                    listMyData.Add(new Task.core.Entities.Data { PropertyName = pName, Value = pValue });
                }
            }
            }
         
            return listMyData;
        }

    }
}
