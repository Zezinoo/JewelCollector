namespace JewelCollector;
/// <summary>
/// Class that represents a Tree Object on the map
/// </summary>
public class Tree : Obstacle, Rechargeable {
        /// <summary>
        /// Overrides ToString method 
        /// </summary>
        /// <returns>Symbol "$$"</returns>
        public override string ToString(){
        Console.ForegroundColor= ConsoleColor.White;
        return "$$ ";
        }
        /// <summary>
        /// Implements Recharge method tied to Rechargeble Interface.Recharge players with +3 energy.
        /// </summary>
        /// <param name="player">Current Player</param>
        public void Recharge(Robot player){
            player.energy = player.energy +3;
    }
}
