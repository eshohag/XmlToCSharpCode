using System;
using System.Xml.Serialization;

namespace XmlToCSharpCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"c:\xmlFileData.txt";
            var objectProperties = XmlToCSharpObject.ObjectProperties(path);
            Console.WriteLine(objectProperties);

            XmlSerializer serializer = new XmlSerializer(typeof(XMLModelAsClass));
            var xMLModelAsClass = new XMLModelAsClass()
            {
                Name = "Shohag",
                ContactNo = "01926029000"
            };
            var xml = @"c:\createXmlFileData.xml";
            //serializer.Serialize(File.Create(xml), xMLModelAsClass);

            var stringwriter = new System.IO.StringWriter();
            serializer.Serialize(stringwriter, xMLModelAsClass);
            var xmlText = stringwriter.ToString();

            Console.ReadKey();
        }
    }
}
