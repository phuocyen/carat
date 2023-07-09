using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;


namespace DoAN.Identity
{
    public class AppUser:IdentityUser
    {
        public DateTime? Birtday { get; set; }

        public string Adress { get; set; }
        public string City { get; set; }
    }
}