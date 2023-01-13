using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseLayer
{
    public class CategoryEntity
    {
        [Key]
        public int Id { get; set; }
        [Required(AllowEmptyStrings =false, ErrorMessage ="Enter Category")]
        public string CategoryName { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="Enter Amount")]
        public float ExpenseLimit { get; set; }
    }
}
