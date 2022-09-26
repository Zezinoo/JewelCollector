namespace JewelCollector;
/// <summary>
/// Abstract class that represents a Jewel object on the map.
/// </summary>
    public abstract class Jewel : ItemMap{
        /// <summary>
        /// Points value of the current player
        /// </summary>
        public int Points ;

    }
/// <summary>
/// Class that represents a Red Jewel object on the map.
/// </summary>
    public class Red : Jewel {
        /// <summary>
        /// Overrides ToString method so it prints correct object symbol on the map.
        /// </summary>
        /// <returns>Returns "JR" symbol</returns>
        public override string ToString() {
            Console.ForegroundColor= ConsoleColor.Red;
            return "JR ";
        }
        /// <summary>
        /// Constructor of Red Jewel, gives it 100 points
        /// </summary>
        public Red(){
            this.Points = 100;
        }
    }

    
/// <summary>
/// Class that represents a Green Jewel Object on the map
/// </summary>
    public class Green : Jewel {
        /// <summary>
        /// Overrides ToString method so it prints correct object symbol on the map.
        /// </summary>
        /// <returns>Returns "JG" symbol</returns>
        public override string ToString() {
            Console.ForegroundColor= ConsoleColor.Green;
            return "JG ";
        }
        /// <summary>
        /// Constructor of Green Jewel, gives it 50 points
        /// </summary>
        public Green(){
            this.Points = 50;
        }
    }

    /// <summary>
    /// Class that represents a Blue Jewel Object on the map
    /// </summary>
    public class Blue : Jewel , Rechargeable {
        /// <summary>
        /// Overrides ToString method so it prints correct object symbol on the map.
        /// </summary>
        /// <returns>Returns "JB" symbol </returns>
        public override string ToString() {
            Console.ForegroundColor= ConsoleColor.Blue;
            return "JB ";
        }
        /// <summary>
        /// Implementation of Recharge method tied to Recharge interface. Blue Jewels recharge energy by 5 points
        /// </summary>
        /// <param name="player">Current player object</param>
        public void Recharge(Robot player){
            player.energy  = player.energy + 5;
        }
        /// <summary>
        /// Constructor of Blue Jewel, gives it 50 points
        /// </summary>
        public Blue(){
            this.Points = 10;
        }
    }   
    



