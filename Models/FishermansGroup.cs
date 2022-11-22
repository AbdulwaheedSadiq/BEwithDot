using System.Collections.Generic;
using BoatPayments.Models;
using loans;

namespace fishers.Models{
    public class FisherMansGroup{
        public int id { get; set; }
        public string crewName { get; set; }
        public string physicalAddress { get; set; }
        public string district  { get; set; }
        public string region { get; set; }
        public string location { get; set; }
        public string  attachments { get; set; }
        

        public List<GroupMembers> GroupMembers { get; set; }

        public List<LoanBoat> LoanBoat { get; set; }

         public List<Payment> Payment { get; set; }
    }
}