using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Dyplom_Rozhko_MVC.Models
{
	public class EmailValidation
	{
		[Required(ErrorMessage = "Введіть свою пошту")]
		[RegularExpression(@"^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Введіть правильну пошту")]
		public string Email { get; set; }
	}
}