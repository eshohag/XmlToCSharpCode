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
            var objectProperties = XmlToCSharpObject.XmlPropertiesToCSharpProperties(path);
            Console.WriteLine(objectProperties);

            #region CSharpModelToXML
            XmlSerializer serializer = new XmlSerializer(typeof(PersonInfo));
            var PersonInfo = new PersonInfo()
            {
                Name = "Shohag",
                ContactNo = "01926029000"
            };
            var stringwriter = new System.IO.StringWriter();
            serializer.Serialize(stringwriter, PersonInfo);
            var xmlText = stringwriter.ToString();
            #endregion

            #region XMLTOCSharpModel
            var xml = @"c:\createXmlFileData.xml";
            var xmlPersonInfo = File.ReadAllText(xml).ParseXML<PersonInfo>();
            #endregion

            #region PostXMLData
            var xmlTextAsString = "";
            var responseResult = XmlHelper.PostXMLData("", xmlTextAsString);
            #endregion

            Console.ReadKey();
        }
    }
}
