namespace JewelCollector;
/// <summary>
/// Class that represents a radioactive object
/// </summary>
public class Radioactive : Obstacle {
    /// <summary>
    /// Overrides method ToString
    /// </summary>
    /// <returns>Returns "!!" Symbol</returns>
    public override string ToString(){
        Console.ForegroundColor= ConsoleColor.DarkYellow;
        return "!! ";
    }
}
