using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocStorage.Models
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Нужен логин")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Без пароля никак")]
        public string Password { get; set; }
    }
}