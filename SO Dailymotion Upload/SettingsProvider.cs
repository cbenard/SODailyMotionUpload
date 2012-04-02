using System;
using System.IO;
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

        public static string Username
        {
            get
            {
                return GetXmlElementValue("username");
            }
        }

        public static string Password
        {
            get
            {
                return GetXmlElementValue("password");
            }
        }

        public static string CallbackUrl
        {
            get
            {
                return GetXmlElementValue("callbackurl");
            }
        }

        private static string GetXmlElementValue(string elementName)
        {
            if (!File.Exists("secrets.xml"))
            {
                throw new Exception("Rename secrets.xml.sample to secrets.xml and enter your secrets in the file.");
            }

            return XDocument.Load("secrets.xml").Element("root").Element(elementName).Value;
        }
    }
}
