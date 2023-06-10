using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_NET105_Nhom3_Shared.ViewModels
{
	public class LoginUser
	{
		[Required(ErrorMessage = "Username cannot be blank")]
		public string? Username { get; set; }

		[Required(ErrorMessage = "Password cannot be blank")]
		public string? Password { get; set; }
	}
}
