using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aster.Web.Models {
    public class SignInModel {

        [Required(ErrorMessage="Please enter username.")]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}