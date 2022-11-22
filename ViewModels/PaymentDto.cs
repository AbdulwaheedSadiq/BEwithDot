using boats.Models;
using fishers.Models;

namespace BoatPayments{
public class PaymentDto{
     public int Status { get; set; }
        public float ammountCredited { get; set; }
        public float ammountdebited { get; set; }
        public string Paidby { get; set; }
        public BoatStock BoatStock { get; set; }
        public FisherMansGroup FisherMansGroup { get; set; }
}
}