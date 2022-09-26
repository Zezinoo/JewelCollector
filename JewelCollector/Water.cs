namespace JewelCollector;
/// <summary>
/// Class that represents a water object on the map
/// </summary>
public class Water : Obstacle {
        /// <summary>
        /// Override toString method
        /// </summary>
        /// <returns>Returns "##" symbol</returns>
        public override string ToString(){
            Console.ForegroundColor= ConsoleColor.White;
        return "## ";
    }
}
