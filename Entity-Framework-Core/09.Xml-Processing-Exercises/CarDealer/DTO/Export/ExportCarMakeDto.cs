using System.Xml.Serialization;

namespace CarDealer
{
    [XmlType("car")]
    public class ExportCarMakeDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}