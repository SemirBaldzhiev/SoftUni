﻿using System.Xml.Serialization;

namespace CarDealer
{
    [XmlType("car")]
    public class ExportCarDistanceDto
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}
