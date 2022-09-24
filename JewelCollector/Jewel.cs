namespace JewelCollector;

    public abstract class Jewel : ItemMap{
        public int Points ;

    }

    public class Red : Jewel {
        
        public override string ToString() {
            return "JR ";
        }
        public Red(){
            this.Points = 100;
        }
    }

    
    public class Green : Jewel {
        
        public override string ToString() {
            return "JG ";
        }
        public Green(){
            this.Points = 50;
        }
    }

    
    public class Blue : Jewel {
        
        public override string ToString() {
            return "JB ";
        }
        public Blue(){
            this.Points = 10;
        }
    }   
    



