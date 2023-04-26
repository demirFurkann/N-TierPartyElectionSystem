using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Vote:BaseEntity
    {
        public int NumberOfVotes { get; set; }
        public int? PartyID { get; set; }
        public int? ProvinceID { get; set; }


        //Relational Properties

        public virtual Party Party { get; set; }

        public virtual Province Province{ get; set; }
    }
}
