namespace JewelCollector;

   class Jewel : ItemMap {
        public int Point { get; set; }
public Jewel(int x, int y) : base(x, y)
        {

        }

   }
    class Red : Jewel {
        public Red(int x, int y) : base(x, y){
            Point = 100;
        }
        public override string ToString(){
            return "JR";
        }
    }

    class Blue : Jewel {
        public Blue(int x, int y) : base(x, y){
            Point = 100;
        }
        
        public override string ToString(){
            return "JB";
        }
    }

    class Green : Jewel {
        public override string ToString(){
            return "JG";
        }
    }