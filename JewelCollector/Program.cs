namespace JewelCollector {

    public abstract class ItemMap {

    }

     public class JewelCollector{
        
        public static void Main() {   
            Map map = new Map(10,10);
            map.firstLevelLayout(map);

            Robot player = new Robot(map,0,0);

            int level = 1; Console.WriteLine("Level: " + level);
            

            bool running = true;
  
            do {

                Console.WriteLine("Enter the command: ");
                string? command = Console.ReadLine();

                if (command == "" || command==null){Console.WriteLine("Enter valid command");continue;}
                if (command.Equals("q")) {
                    running = false;
                } else if (command.Equals("w")) {
                    player.MoveNorth();
                } else if (command.Equals("a")) {
                    player.MoveWest();
                } else if (command.Equals("s")) {
                    player.MoveSouth();
                } else if (command.Equals("d")) {
                    player.MoveEast();
                } else if (command.Equals("g")) {
                    player.CollectJewel();
                    player.GetRechargeable();
                    Console.Clear();
                    map.Print();
                }
                player.checkRadioctive();
                Console.WriteLine($"Points : {player.points} Bag Size : {player.bag.Count()} Energy : {player.energy}");
                if(player.energy < 0){Console.WriteLine("No energy left, you lost") ; running = false;}
                if(map.noJewelsLeft(map) && level<30){

                    level++;Console.WriteLine("Level: " + level);
                    int points = player.points; int energy = player.energy;
                    int w = map.Width; int h = map.Height;
                    map = new Map(w+1, h+1);
                    int[] num = map.newItemMapQuantity(map);
                    map.randomLevelLayout(map,num[0],num[1],num[2]);
                    player = new Robot(map,0,0); player.points = points; player.energy = energy;
                }
                if(level == 30){Console.WriteLine("Game Over"); running = false;}
            } while (running);
        
        }  
     }

}
