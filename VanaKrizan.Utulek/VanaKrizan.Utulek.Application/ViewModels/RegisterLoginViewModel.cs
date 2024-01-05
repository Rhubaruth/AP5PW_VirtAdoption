using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanaKrizan.Utulek.Application.ViewModels
{
	public class RegisterLoginViewModel
	{
		public RegisterViewModel? Register { get; set; }
		public LoginViewModel? Login { get; set; }
		public bool LoginFailed { get; set; }


	}
}
