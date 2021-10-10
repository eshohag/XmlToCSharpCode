using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XmlToCSharpCode
{
    public static class XmlHelper
    {
        public static string XmlPropertiesToCSharpProperties(string path)
        {
            string line;
            string objectProperties = "";

            System.IO.StreamReader file = new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                #region Data Example- <ban:CounRiskImp>3</ban:CounRiskImp>

                if (!string.IsNullOrWhiteSpace(line) && line.Contains(":"))
                {
                    line = line.Trim();
                    var split = line.Split(':')[1].Split('>');
                    var propertyName = split[0];
                    var propertyValue = split[1].Split('<')[0];
                    if (propertyValue.GetType() == typeof(string))
                    {
                        propertyValue = "'" + propertyValue + "'";
                    }
                    var fullProperty = "aAddCustomer.Data." + propertyName + "=" + propertyValue + ";";
                    objectProperties += fullProperty + "\n";
                }
                #endregion

                #region Data Example-  <TellerNum>5000055</TellerNum>

                else if (!string.IsNullOrWhiteSpace(line))
                {
                    line = line.Trim();
                    var split = line.Split('<')[1].Split('>');
                    var propertyName = split[0];
                    var propertyValue = split[1];

                    if (propertyValue.GetType() == typeof(string))
                    {
                        propertyValue = "'" + propertyValue + "'";
                    }
                    var fullProperty = "aAddCustomer.Data." + propertyName + "=" + propertyValue + ";";

                    objectProperties += fullProperty + "\n";
                }
                #endregion
            }
            file.Close();
            return objectProperties;
        }

        public static string PostXMLData(string destinationUrl, string requestXml)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(destinationUrl);
            byte[] bytes;
            bytes = System.Text.Encoding.ASCII.GetBytes(requestXml);
            request.ContentType = "text/xml; encoding='utf-8'";
            request.ContentLength = bytes.Length;
            request.Method = "POST";
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseStr = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return responseStr;
            }
            return null;
        }

        public static Stream ToStream(this string xmlResponse)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(xmlResponse);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static T ParseXML<T>(this string xmlResponse) where T : class
        {
            var reader = XmlReader.Create(xmlResponse.Trim().ToStream(), new XmlReaderSettings() { ConformanceLevel = ConformanceLevel.Document });
            return new XmlSerializer(typeof(T)).Deserialize(reader) as T;
        }

        //Implemented based on interface, not part of algorithm
        public static string RemoveXMLNamespaces(this string xmlDocument)
        {
            XElement xmlDocumentWithoutNs = RemoveXMLNamespaces(XElement.Parse(xmlDocument));
            return xmlDocumentWithoutNs.ToString();
        }

        //Core recursion function
        private static XElement RemoveXMLNamespaces(XElement xmlDocument)
        {
            if (!xmlDocument.HasElements)
            {
                XElement xElement = new XElement(xmlDocument.Name.LocalName);
                xElement.Value = xmlDocument.Value;

                foreach (XAttribute attribute in xmlDocument.Attributes())
                    xElement.Add(attribute);

                return xElement;
            }
            return new XElement(xmlDocument.Name.LocalName, xmlDocument.Elements().Select(el => RemoveXMLNamespaces(el)));
        }
    }
}
