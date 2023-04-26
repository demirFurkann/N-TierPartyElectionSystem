using Project.BLL.DesignPatterns.SingletonPattern;
using Project.BLL.Repositories.BaseRep;
using Project.DAL.ContextClasses;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Repositories.ConcRep
{
    public class PartyRepository : BaseRepository<Party>
    {
        public PartyRepository()
        {

        }

    }
}

