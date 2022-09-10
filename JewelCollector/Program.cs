namespace JewelCollector {
 

    abstract class Obstacle : ItemMap
    {

    }

    class Water : Obstacle
    {

    }



    public class JewelCollector {

        public static void Main() {
            

            var JewelPos = new List<(Jewel,int[])>(){
                {(new Red() , new int[] {1,9})},
                {(new Red() , new int[] {8, 8})},
                {("Green" , new int[] {9, 1})},
                {("Green" , new int [] {7, 6})},
                {("Blue" , new int []  {3, 4})},
                {("Blue" , new int [] {2, 1})}
            };

            var ObstaclePos = new List<string,int[]>(){
                {"Water" , new int[] {5,0}},
                {"Water" , new int[] {5, 1}},
                {"Water" , new int[] {5,2}},
                {"Water" , new int[] {5, 3}},
                {"Water" , new int[] {5,4}},
                {"Water" , new int[] {5, 5}},
                {"Water" , new int[] {5,6}},
                {"Tree" , new int[] {5, 9}},
                {"Tree" , new int[] {3, 9}},
                {"Tree" , new int[] {8, 3}},
                {"Tree" , new int[] {2, 5}},
                {"Tree" , new int[] {1, 4}},

            };

            bool running = false;
        
            do {
        
                Console.WriteLine("Enter the command: ");
                string command = Console.ReadLine();
        
                if (command.Equals("quit") ) {
                    running = false;
                } else if (command.Equals("w")) {
                    
                } else if (command.Equals("a")) {
                    
                } else if (command.Equals("s")) {
                    
                } else if (command.Equals("d")) {
                
                } else if (command.Equals("g")) {
                    
                }
            } while (running);
            Map map = new Map(JewelPos,ObstaclePos);
            map.PrintMap();
        }
    }
}