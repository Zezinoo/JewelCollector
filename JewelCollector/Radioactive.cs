namespace JewelCollector;

public class Radioactive : Obstacle {
    public override string ToString(){
        Console.ForegroundColor= ConsoleColor.DarkYellow;
        return "!! ";
    }
}
