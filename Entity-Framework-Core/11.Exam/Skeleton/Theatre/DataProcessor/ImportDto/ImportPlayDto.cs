﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using Theatre.Data.Models.Enums;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class ImportPlayDto
    {
        [XmlElement("Title")]
        [MinLength(4)]
        [MaxLength(50)]
        [Required]
        public string Title { get; set; }

        [XmlElement("Duration")]
        [Required]
        public string Duration { get; set; }

        [XmlElement("Rating")]
        [Range(0.00, 10.00)]
        [Required]
        public float Rating { get; set; }

        [XmlElement("Genre")]
        [Required]
        public string Genre { get; set; }

        [XmlElement("Description")]
        [MaxLength(700)]
        [Required]
        public string Description { get; set; }

        [XmlElement("Screenwriter")]
        [MinLength(4)]
        [MaxLength(30)]
        [Required]
        public string Screenwriter { get; set; }

    }
}
