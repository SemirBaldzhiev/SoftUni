using System.Xml.Serialization;

namespace CarDealer
{
    [XmlType("part")]
    public class ExportCarPartsDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}