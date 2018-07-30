﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JwtTokenDemo.Model
{
    public class LoginModel
    {

        [Required(ErrorMessage = "请输入用户名！")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "请输入密码！")]
        public string  Password { get; set; }

    }
}
