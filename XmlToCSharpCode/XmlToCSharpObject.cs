namespace XmlToCSharpCode
{
    public class XmlToCSharpObject
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
    }
}
