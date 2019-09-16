using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blahgger.Models
{
    public class LoginUser
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }

        // TODO Hmm... should this property go on this model???
        [Required]
        public string Password { get; set; }
    }
}