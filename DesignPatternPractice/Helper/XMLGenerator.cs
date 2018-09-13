using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace DesignPatternPractice.Helper
{
    public static class XMLGenerator
    {
        public static string GetXMLFromObject(object o)
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter tw = null;
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            try
            {
                XmlSerializer serializer = new XmlSerializer(o.GetType());

                tw = new XmlTextWriter(sw);

                serializer.Serialize(tw, o, ns);
            }
            catch (Exception ex)
            {
                //Handle Exception Code
            }
            finally
            {
                sw.Close();
                if (tw != null)
                {
                    tw.Close();
                }
            }
            return sw.ToString();
        }
    }
}
