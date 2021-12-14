using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Xml.Linq;

namespace WebAPIDynamicExample.Util
{
    // Full credit to Scott Guthrie https://www.youtube.com/watch?v=bcCKF582_80
    public static class ExpandoXml
    {
        public static dynamic AsExpando(this XDocument xmldocument)
        {
            return CreateExpando(xmldocument.Root);
        }

        private static dynamic CreateExpando(XElement element)
        {
            var result = new ExpandoObject() as IDictionary<string, object>;
            if (element.Elements().Any(e => e.HasElements))
            {
                var list = new List<ExpandoObject>();
                result.Add(element.Name.ToString(), list);
                foreach(var childElement in element.Elements())
                {
                    list.Add(CreateExpando(childElement));
                }
            }
            else
            {
                foreach(var leaf in element.Elements())
                {
                    result.Add(leaf.Name.ToString(), leaf.Value);
                }
            }
            return result;
        }
    }
}
