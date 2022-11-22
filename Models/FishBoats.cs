using boats.Models;

namespace fboats.Models{

    public class Fishboats{
        public int FishBoatsId { get; set; }
        public string  noOfTraps { get; set; }


        public int BoatStockId {get; set;}
       public BoatStock BoatStock { get; set;}
    }

}