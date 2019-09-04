using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class UserLoginModel
    {
        public int Uid { get; set; }
       

        [Display(Name ="아이디")]
        [Required(ErrorMessage ="아이디를 입력하세요")]
        [StringLength(25,MinimumLength =3, ErrorMessage ="아이디는 3자리이상 25자리 이하로 입력하시오")]

        public string Id { get; set; }

        

        [Display(Name ="비밀 번호")]
        [Required(ErrorMessage ="비밀번호를 입력하세요")]
        [StringLength(20, MinimumLength =6, ErrorMessage ="비밀번호는 6자리이상 20자 이하로 입력하시오")]

        public string Pw { get; set; }
    }
}
