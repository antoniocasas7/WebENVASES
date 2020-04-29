using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiJWT_Swagger.Models
{
    public class UsuarioLogin
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
    }
}