using System.Xml.Serialization;

namespace CarDealer
{
    [XmlType("partId")]
    public class ImportPartIdDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}