using ng_project.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ng_project.web.Models
{
    public class RegisterModel :LoginModel
    {
		public bool IsParticipant { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }

        //[Required(ErrorMessage = "Не указан Email")]
        [DataType(DataType.EmailAddress)]
		public string Email { get; set; }
	}
}
