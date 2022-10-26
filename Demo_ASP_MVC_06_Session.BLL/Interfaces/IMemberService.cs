using Demo_ASP_MVC_06_Session.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ASP_MVC_06_Session.BLL.Interfaces
{
    public interface IMemberService
    {
        public Member? Register(Member memberData);

        public Member? Login(string identifiant, string password);
    }
}
