using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dyplom_Rozhko_MVC.Models
{
	public class RegisterViewModel
	{
        [Required(ErrorMessage = "Введіть свою пошту")]
        [RegularExpression(@"^[a-zA-Z0-9_\.-]+@([a-zA-Z0-9-]+\.)+[a-zA-Z]{2,6}$",
        ErrorMessage = "Введіть правильну пошту")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введіть ім'я користувача")]
        public string NameUser { get; set; }

        [Required(ErrorMessage = "Введіть справжнє ім'я")]
        public string RealNameUser { get; set; }

        [Required(ErrorMessage = "Введіть номер телефону")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Введіть правильний номер")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Введіть пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}