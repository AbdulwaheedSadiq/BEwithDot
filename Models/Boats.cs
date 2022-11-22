using System.Collections.Generic;
using BoatPayments.Models;
using fboats.Models;
using loans;

namespace boats.Models{
    public class BoatStock{
        public int BoatStockId { get; set; }

        public string sneb { get; set; }

        public string sneg { get; set;}

        public string  lifeJacket { get; set; }

        public string  boatLength { get; set; }

        public string type { get; set; }

        public float boatPrice { get; set; }    

        public int noAnchor { get; set; }

        public int noOfRope { get; set; }   

        public string  status { get; set; }

        public Fishboats FishBoats { get; set; }

        public List<LoanBoat> LoanBoat { get; set; }

         public List<Payment> Payment { get; set; }

    }
}