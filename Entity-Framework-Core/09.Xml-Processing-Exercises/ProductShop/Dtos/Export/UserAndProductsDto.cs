using System.Xml.Serialization;

namespace ProductShop
{
    public class UserAndProductsDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public UserWithProductsDto[] Users { get; set; }
    }
}