using System.Xml.Serialization;

namespace XmlToCSharpCode
{
    // using System.Xml.Serialization;
    // XmlSerializer serializer = new XmlSerializer(typeof(Envelope));
    // using (StringReader reader = new StringReader(xml))
    // {
    //    var test = (Envelope)serializer.Deserialize(reader);
    // }

    [XmlRoot(ElementName = "RsHeader")]
    public class RsHeader
    {

        [XmlElement(ElementName = "Filler1")]
        public int Filler1;

        [XmlElement(ElementName = "MsgLen")]
        public int MsgLen;

        [XmlElement(ElementName = "Filler2")]
        public int Filler2;

        [XmlElement(ElementName = "MsgTyp")]
        public int MsgTyp;

        [XmlElement(ElementName = "Filler3")]
        public int Filler3;

        [XmlElement(ElementName = "CycNum")]
        public int CycNum;

        [XmlElement(ElementName = "MsgNum")]
        public int MsgNum;

        [XmlElement(ElementName = "SegNum")]
        public int SegNum;

        [XmlElement(ElementName = "FrntEndNum")]
        public int FrntEndNum;

        [XmlElement(ElementName = "TermlNum")]
        public int TermlNum;

        [XmlElement(ElementName = "InstNum")]
        public int InstNum;

        [XmlElement(ElementName = "BrchNum")]
        public int BrchNum;

        [XmlElement(ElementName = "WorkstationNum")]
        public int WorkstationNum;

        [XmlElement(ElementName = "TellerNum")]
        public int TellerNum;

        [XmlElement(ElementName = "TrnNum")]
        public int TrnNum;

        [XmlElement(ElementName = "JrnlNum")]
        public int JrnlNum;

        [XmlElement(ElementName = "RsHdrDt")]
        public int RsHdrDt;

        [XmlElement(ElementName = "Filler4")]
        public int Filler4;

        [XmlElement(ElementName = "Filler5")]
        public int Filler5;

        [XmlElement(ElementName = "Filler6")]
        public int Filler6;

        [XmlElement(ElementName = "Flag1")]
        public int Flag1;

        [XmlElement(ElementName = "Flag2")]
        public int Flag2;

        [XmlElement(ElementName = "Flag3")]
        public int Flag3;

        [XmlElement(ElementName = "Flag4")]
        public int Flag4;

        [XmlElement(ElementName = "Filler9")]
        public string Filler9;

        [XmlElement(ElementName = "OutputType")]
        public int OutputType;
    }

    [XmlRoot(ElementName = "OkMessage")]
    public class OkMessage
    {

        [XmlElement(ElementName = "RcptData")]
        public string RcptData;

        [XmlElement(ElementName = "Filler2")]
        public string Filler2;

        [XmlElement(ElementName = "CustNum")]
        public int CustNum;

        [XmlElement(ElementName = "Filler1")]
        public int Filler1;

        [XmlElement(ElementName = "AcctNum")]
        public int AcctNum;
    }
    [XmlRoot(ElementName = "ErrorMessage")]
    public class ErrorMessageCTS
    {

        [XmlElement(ElementName = "SupOverRide")]
        public int SupOverRide;

        [XmlElement(ElementName = "ErrorCode")]
        public int ErrorCode;

        [XmlElement(ElementName = "ErrorMessage")]
        public string ErrorMessage;
    }
    [XmlRoot(ElementName = "Stat")]
    public class Stat
    {

        [XmlElement(ElementName = "OkMessage")]
        public OkMessage OkMessage;

        [XmlElement(ElementName = "ErrorMessage")]
        public ErrorMessageCTS ErrorMessage;
    }

    [XmlRoot(ElementName = "CustAddRs")]
    public class CustAddRs
    {

        [XmlElement(ElementName = "RsHeader")]
        public RsHeader RsHeader;

        [XmlElement(ElementName = "Stat")]
        public Stat Stat;
    }

    [XmlRoot(ElementName = "createCustomerResponse")]
    public class CreateCustomerResponse
    {

        [XmlElement(ElementName = "CustAddRs")]
        public CustAddRs CustAddRs;
    }

    [XmlRoot(ElementName = "Body")]
    public class Body
    {

        [XmlElement(ElementName = "createCustomerResponse")]
        public CreateCustomerResponse CreateCustomerResponse;
    }

    [XmlRoot(ElementName = "Envelope")]
    public class Envelope
    {

        [XmlElement(ElementName = "Body")]
        public Body Body;
    }
}