using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface In_VarIRepo<CLASS, ID>
    {
        bool createVar(ID email, ID code);
        bool checkVar(ID email, ID code);
        bool checkMail(ID email);
    }
}
