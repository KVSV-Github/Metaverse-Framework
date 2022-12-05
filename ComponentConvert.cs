using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;

namespace KVSV.Metaverse
{
    public static class ComponentConvert
    {
        private const string delimiter = ":";

        public static ExpandoObject Deserialize(string source)
        {
            dynamic newComponent = new ExpandoObject();

            using(StringReader reader = new StringReader(source))
            {
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    string identifier = line.Substring(0, line.IndexOf(delimiter) - 1).Trim();
                    string value = line.Substring(line.IndexOf(delimiter) + 1).Trim();

                    if (identifier == "Id")
                    {
                        ((IDictionary<string, object>)newComponent).Add(identifier, value);
                    }
                    else
                    {
                        Type t = Type.GetType(value);
                        ((IDictionary<string, object>)newComponent).Add(identifier, t);
                    }
                }
            }

            return newComponent;
        }

        public static string Serialize(dynamic component)
        {
            string serializedComponent = "";

            foreach (KeyValuePair<string, object> kvp in component)
            {
                string line = kvp.Key + " : " + kvp.Value.ToString() + "\n";
                serializedComponent += line;
            }

            return serializedComponent;
        }
    }
}
