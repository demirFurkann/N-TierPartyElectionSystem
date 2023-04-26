using Project.BLL.Repositories.BaseRep;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Repositories.ConcRep
{
    public class VoteRepository:BaseRepository<Vote>
    {
        public VoteRepository()
        {

        }
        public List<Province> GetAllByProvinceId(int provinceId)
        {
            return _db.Provinces.Where(d => d.ID == provinceId).ToList();
        }
    }
}
