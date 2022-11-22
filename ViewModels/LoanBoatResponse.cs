using System;
using boats.Models;
using fishers.Models;

namespace loans {
    public class LoanBoatResponse{
         public string attachment { get; set; }
        public string BoatCodeNumbergenerated { get; set; }
        public string status { get; set; }
        public DateTime date { get; set; } 
        public float CreditCost { get; set; }
        public string HiredBy { get; set; }

        public BoatStock BoatStock { get; set; }

        public FisherMansGroup FisherMansGroup { get; set; }
    }
}