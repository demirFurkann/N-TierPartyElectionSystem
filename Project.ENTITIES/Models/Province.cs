using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Province:BaseEntity
    {
        public string ProvinceName { get; set; }
        
        public int NumberOfVotes { get; set; }

        //Relational Properties

        public virtual List<Party> Parties { get; set; }
        public virtual List<Vote> Votes { get; set; }


        public Province()
        {
            Parties = new List<Party>();
        }
    }
}
