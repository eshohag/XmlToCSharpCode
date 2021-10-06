using System.IO;
using System.Net;

namespace XmlToCSharpCode
{
    public class XmlToCSharpObject
    {

        public static string ObjectProperties(string path)
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
            HttpWebResponse response;
            response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream responseStream = response.GetResponseStream();
                var responseStr = new StreamReader(responseStream).ReadToEnd();
                return "Ok";
            }
            return null;
        }
    }
}