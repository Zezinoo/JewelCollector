namespace JewelCollector;
/// <summary>
/// Class representes empty space on map with symbol -- .
/// </summary>
public class Empty : Obstacle {
    /// <summary>
    /// Overrides ToString method so it prints correct Symbol.
    /// </summary>
    /// <returns>Returns -- symbol</returns>
    public override string ToString(){
        Console.ForegroundColor= ConsoleColor.White;
        return "-- ";
    }
}
