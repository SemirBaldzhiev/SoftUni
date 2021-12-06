using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theatre.Data.Models
{
    public class Cast
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(40)]
        [Required]
        public string FullName  { get; set; }

        [Required]
        public bool IsMainCharacter  { get; set; }

        [Required]
        public string PhoneNumber  { get; set; }

        [ForeignKey(nameof(Play))]
        [Required]
        public int PlayId { get; set; }
        public virtual Play Play { get; set; }

    }
}
