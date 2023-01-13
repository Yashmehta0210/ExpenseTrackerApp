using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseLayer
{
    public class ExpenseEntity
    {
        [Key]
        public int ExpenseId { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="Please fill the details")]
        public string Title { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="Select the Category")]
        public int Id { get; set; }

           
        [Required(AllowEmptyStrings =false,ErrorMessage ="Please select the date and time")]
        public DateTime DateTime { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="Please enter amount")]
        public float ExpenseAmount { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="Please fill the details")]
        public string Description { get; set; } 
        public int UserId { get; set; }
        [Required(AllowEmptyStrings =false, ErrorMessage ="Select the Category")]
        public string CategoryName { get; set; }    
    }
}
