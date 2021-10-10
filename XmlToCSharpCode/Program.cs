using System;
using System.IO;
using System.Xml.Serialization;

namespace XmlToCSharpCode
{
    class Program
    {
        static void Main(string[] args)
        {

            var path = @"c:\xmlFileData.txt";
            var objectProperties = XmlToCSharpCode.XmlHelper.XmlPropertiesToCSharpProperties(path);
            Console.WriteLine(objectProperties);

            #region CSharpModelToXML
            //XmlSerializer serializer = new XmlSerializer(typeof(PersonInfo));
            //var PersonInfo = new PersonInfo()
            //{
            //    Name = "Shohag",
            //    ContactNo = "01926029000"
            //};
            //var stringwriter = new System.IO.StringWriter();
            //serializer.Serialize(stringwriter, PersonInfo);
            //var xmlText = stringwriter.ToString();
            #endregion

            #region XMLTOCSharpModel
            //var xml = @"c:\createXmlFileData.xml";
            //var xmlPersonInfo = File.ReadAllText(xml).ParseXML<PersonInfo>();
            #endregion

            #region PostXMLData
            //var xmlTextAsString = "";
            //var responseResult = XmlToCSharpCode.XmlHelper.PostXMLData("", xmlTextAsString);
            #endregion

            #region Success Or Failed Response Read
            var xml = File.ReadAllText(@"c:\createXmlFileData.xml");

            string XmlHelper = xml.RemoveXMLNamespaces();

            XmlSerializer serializer = new XmlSerializer(typeof(EnvelopeTCSResponse));
            using (StringReader reader = new StringReader(XmlHelper))
            {
                var success = (EnvelopeTCSResponse)serializer.Deserialize(reader);
            }

            var failed = File.ReadAllText(@"c:\Failed.xml");
            var failedString = failed.RemoveXMLNamespaces();
            using (StringReader reader = new StringReader(failedString))
            {
                var failedResult = (EnvelopeTCSResponse)serializer.Deserialize(reader);
            }
            #endregion

            Console.ReadKey();
        }
    }
}
