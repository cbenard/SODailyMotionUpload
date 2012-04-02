using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SO_Dailymotion_Upload
{
    public static class SettingsProvider
    {
        public static string Key
        {
            get
            {
                return GetXmlElementValue("key");
            }
        }

        public static string Secret
        {
            get
            {
                return GetXmlElementValue("secret");
            }
        }

        private static string GetXmlElementValue(string elementName)
        {
            return XDocument.Load("secrets.xml").Element("root").Element(elementName).Value;
        }
    }
}
