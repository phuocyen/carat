using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;


namespace DoAN.Identity
{
    public class appUserStore : UserStore<AppUser>
    {
        public appUserStore(AppDbContext dbContext) : base(dbContext) { }
    }
}