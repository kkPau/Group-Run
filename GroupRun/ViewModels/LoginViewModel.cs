using System;
using System.ComponentModel.DataAnnotations;

namespace GroupRun.ViewModels
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "Email is requred")]
		[Display(Name = "Email Address")]
		public string EmailAddress { get; set; }

		[Required(ErrorMessage = "Password is requred")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}

