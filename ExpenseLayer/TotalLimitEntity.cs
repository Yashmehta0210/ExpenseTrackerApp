using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseLayer
{
    public class TotalLimitEntity
    {

        [Key]
        public int LimitId{get; set;}

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter amount")]
        public float TotalAmount { get; set; }
        public int UserId { get; set; }

    }
}
