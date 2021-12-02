﻿using System.Xml.Serialization;

namespace ProductShop
{
    [XmlType("User")]
    public class UserWithProductsDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }

        [XmlElement("SoldProducts")]
        public SoldProductDto SoldProducts { get; set; }
    }
}