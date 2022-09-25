namespace JewelCollector;

public abstract class Obstacle : ItemMap 
{

}

public class Empty : Obstacle {
    public override string ToString(){
        Console.ForegroundColor= ConsoleColor.White;
        return "-- ";
    }
}

public class Water : Obstacle {
        public override string ToString(){
            Console.ForegroundColor= ConsoleColor.White;
        return "## ";
    }
}

public class Tree : Obstacle, Rechargeable {
        public override string ToString(){
        Console.ForegroundColor= ConsoleColor.White;
        return "$$ ";
        }
        public void Recharge(Robot player){
            player.energy = player.energy +3;
    }
}

public class Radioactive : Obstacle {
    public override string ToString(){
        Console.ForegroundColor= ConsoleColor.DarkYellow;
        return "!! ";
    }
}

