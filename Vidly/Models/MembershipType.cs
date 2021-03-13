using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MembershipType
    {
        [KeyAttribute()]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public Byte DurationInMonth { get; set; }

        public Byte Discount { get; set; }

        public Byte SignupFee { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public static readonly Byte UNKNOWN = 0;
        public static readonly Byte PAYASYOUGO = 21;
    }
}