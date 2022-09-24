namespace JewelCollector;

public abstract class Obstacle : ItemMap 
{

}

public class Empty : Obstacle {
    public override string ToString(){
        return "-- ";
    }
}

public class Water : Obstacle {
        public override string ToString(){
        return "## ";
    }
}

public class Tree : Obstacle {
        public override string ToString(){
        return "$$ ";
    }
}

