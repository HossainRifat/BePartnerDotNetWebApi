using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface In_IdeaIRepo<CLASS, ID>
    {
        List<CLASS> GetMyInvestment(ID email);
        CLASS GetByEnEmail(ID email);
        List<CLASS> GetByConfirmed();

        CLASS GetByName(ID name);

        List<CLASS> SearchIdea(ID CompanyName);

        List<CLASS> SortCAZ();

        List<CLASS> SortCZA();

        List<CLASS> SortV19();

        List<CLASS> SortV91();

        List<CLASS> SortS19();

        List<CLASS> SortS91();

    }
}
