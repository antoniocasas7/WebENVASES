using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMODELO_envases
{
    public interface IEmpleo
    {
        Task<MIMODELO_envases.Empleo> Details(int? id);

        Task<bool> Create(MIMODELO_envases.Empleo empleo);

        Task<MIMODELO_envases.Empleo> EditByEmpleo(MIMODELO_envases.Empleo empleo);

        Task<MIMODELO_envases.Empleo> EditById(int? id);

        Task<List<MIMODELO_envases.Empleo>> List();

        Task<Empleo> DeleteByEmpleo(Empleo empleo);


    }
}
