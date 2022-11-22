using boats.Models;
using fishers.Models;

namespace BoatPayments.Models{
    public class Payment{
        public int PaymentId { get; set; }
        public int Status { get; set; }
        public float ammountCredited { get; set; }
        public float ammountdebited { get; set; }
        public string Paidby { get; set; }

        public int BoatStockId { get; set; }
        public BoatStock BoatStock { get; set; }

        public int FisherMansGroupId { get; set; }
        public FisherMansGroup FisherMansGroup { get; set; }
    }
}