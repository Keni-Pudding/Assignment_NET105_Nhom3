using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_NET105_Nhom3_Shared.ViewModels
{
	public class RegisterUser
	{

		[Required(ErrorMessage = "Username cannot be blank")]
		public string? Username { get; set; }

		[Required(ErrorMessage = "Email cannot be blank")]
		[EmailAddress]
		public string? Email { get; set; }

		[Required(ErrorMessage = "Password cannot be blank")]
		public string? Password { get; set; }

		[Required(ErrorMessage = "Confirm password cannot be blank")]
		public string? ConfirmPassword { get; set; }

		[Required(ErrorMessage = "Name cannot be blank")]
		public string? Name { get; set; }
	}
}
