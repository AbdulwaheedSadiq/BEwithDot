using System;

namespace loans{

    public class LoanBoatRequest{
          public int LoanBoatId { get; set; }
        public string attachment { get; set; }
        public string HiredBy { get; set; }

          public int BoatStockId { get; set; }

      public int FisherMansGroupId { get; set; }
    }
}