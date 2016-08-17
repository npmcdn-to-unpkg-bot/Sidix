using Dixus.Entidades.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Dixus.Domain
{
    public class MyUserManager : UserManager<MyUser, string>
    {
        public MyUserManager()
            : base(new UserStore<MyUser, MyRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>(new DixusContext()))
        {
            
        }
        public MyUserManager(DixusContext context)
            : base(new UserStore<MyUser, MyRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>(context))
        {

        }
    }

    public class MyRoleManager : RoleManager<MyRole>
    {
        public MyRoleManager()
            : base(new RoleStore<MyRole>(new DixusContext()))
        {

        }
        public MyRoleManager(DixusContext context)
            : base(new RoleStore<MyRole>(context))
        {

        }

    }

}
