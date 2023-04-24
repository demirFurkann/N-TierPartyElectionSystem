using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Party : BaseEntity
    {
        public string PartyName { get; set; }
        public int? ProvinceID { get; set; }

        //Relational Properties

        public virtual Province Province { get; set; }
        public virtual List<Vote> Votes { get; set; }


    }
}
