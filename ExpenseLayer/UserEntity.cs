using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseLayer
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="Enter Username")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings=false,ErrorMessage ="Enter EmailId")]
        public string Email { get; set; }

        [Required (AllowEmptyStrings =false,ErrorMessage ="Enter Password")]
        public string Password { get; set; }

    }
}
