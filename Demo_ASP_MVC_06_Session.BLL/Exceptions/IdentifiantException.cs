using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ASP_MVC_06_Session.BLL.Exceptions
{
    public class IdentifiantException : Exception
    {
        public IdentifiantException(string? message) : base(message)
        { }
    }

    public class IdentifiantIsNotValidException : IdentifiantException
    {
        public IdentifiantIsNotValidException()
            : base("Identidfiant non valide!")
        {
        }
    }

    public class IdentifiantAlreadyExistsException : IdentifiantException
    {
        public IdentifiantAlreadyExistsException() 
            : base("L'identifiant existe déjà!")
        {
        }
    }

    public class IdentifiantNotExistsException : IdentifiantException
    {
        public IdentifiantNotExistsException() 
            : base("L'identifiant n'existe pas!")
        {
        }
    }

}
