
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BasicallyMe.RobinhoodNet
{

    public class NewACHSingle
    {
        public Url<ACHRelationship> ACHRelationship { get; set; }
        public string Direction { get; set; }
        public decimal Amount { get; set; }

        public NewACHSingle()
        {
        }
    }

}
