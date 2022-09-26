namespace JewelCollector {
 
    /// <summary>
    /// Class that contains methods to run the game
    /// </summary>
     public class JewelCollector{

        delegate void MoveNorth();
        delegate void MoveSouth();
        delegate void MoveEast();
        delegate void MoveWest();
        delegate void Collect();

        static event MoveNorth? OnMoveNorth; 
        static event MoveSouth? OnMoveSouth; 
        static event MoveEast? OnMoveEast;

        static event MoveWest? OnMoveWest;
        static event Collect? OnCollect;

        /// <summary>
        /// Main method, where the game is ran
        /// </summary>
        public static void Main() {   
            Map map = new Map(10,10);
            map.firstLevelLayout(map);

            Robot player = new Robot(map,0,0);

            int level = 1; Console.WriteLine("Level: " + level);
            
            OnMoveNorth += player.MoveNorth;
            OnMoveSouth += player.MoveSouth;
            OnMoveEast += player.MoveEast;
            OnMoveWest += player.MoveWest;
            OnCollect += player.Collect;


            bool running = true;
            /// <summary>
            /// Do-while loop that checks player movement, update map , checks game end and level end. While bool runnnig is true the game still runs
            /// </summary>
            /// <value></value>
            do {

                Console.WriteLine("Enter the command: ");
                ConsoleKeyInfo cmd = Console.ReadKey(true);
                string command = cmd.Key.ToString();

                if (command.Equals("") || command==null){Console.WriteLine("Enter valid command");continue;}
                if (command.Equals("Q")) {
                    running = false;
                } else if (command.Equals("W")) {
                    OnMoveNorth();
                } else if (command.Equals("A")) {
                    OnMoveWest();
                } else if (command.Equals("S")) {
                    OnMoveSouth();
                } else if (command.Equals("D")) {
                    OnMoveEast();
                } else if (command.Equals("G")) {
                    OnCollect();
                    Console.Clear();
                    map.Print();
                    
                }
                player.checkRadioctive();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Points : {player.points} Bag Size : {player.bag.Count()} Energy : {player.energy}");
                if(player.energy < 0){Console.WriteLine("No energy left, you lost") ; running = false;}
                if(map.noJewelsLeft(map) && level<21){
                    Console.Clear();
                    OnMoveNorth -= player.MoveNorth;
                    OnMoveSouth -= player.MoveSouth;
                    OnMoveEast -= player.MoveEast;
                    OnMoveWest -= player.MoveWest;
                    OnCollect -= player.Collect;
                    Console.WriteLine("Level Passed");
                    level++;Console.WriteLine("Current Level is : " + level);
                    int points = player.points; int energy = player.energy;
                    int w = map.Width; int h = map.Height;
                    map = new Map(w+1, h+1);
                    int[] num = map.newItemMapQuantity(map);
                    map.randomLevelLayout(map,num[0],num[1],num[2]);
                    player = new Robot(map,0,0); player.points = points; player.energy = Math.Max(energy,20);//20 energy so it makes the game easier
                    OnMoveNorth += player.MoveNorth;
                    OnMoveSouth += player.MoveSouth;
                    OnMoveEast += player.MoveEast;
                    OnMoveWest += player.MoveWest;
                    OnCollect += player.Collect;
                }
                if(level == 21){Console.WriteLine("Game Over"); running = false;}
            } while (running);
        
        }  
     }

}
