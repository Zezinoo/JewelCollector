namespace JewelCollector;

public class Empty : Obstacle {
    public override string ToString(){
        Console.ForegroundColor= ConsoleColor.White;
        return "-- ";
    }
}
