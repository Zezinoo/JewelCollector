﻿namespace JewelCollector {

    public class ItemMap {

    }

    public class Map {

        public ItemMap[,] mapMatrix ; 
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Map(int width, int height) { 
            Width = width; Height = height;
            mapMatrix = new ItemMap[width, height];
            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++) {
                    mapMatrix[i,j] = new Empty();
                 }
            }

        }
                
        public void Print() {
            for (int i = 0; i < mapMatrix.GetLength(0); i++) {
                for (int j = 0; j < mapMatrix.GetLength(1); j++) {
                Console.Write(mapMatrix[i, j]);
                }
                Console.Write("\n");
            }
        }

        public void Insert (ItemMap Item , int i, int j){
            mapMatrix[i,j] = Item;
        }

        public void firstLevelLayout (Map map){
            map.Insert(new Red(),1, 9);
            map.Insert(new Red(),8,8);
            map.Insert(new Green(),8,8);
            map.Insert(new Green(),7,6);
            map.Insert(new Blue(),3,4);
            map.Insert(new Blue(),2,1);

            map.Insert(new Water(),5,0);
            map.Insert(new Water(),5,1);
            map.Insert(new Water(),5,2);
            map.Insert(new Water(),5,3);
            map.Insert(new Water(),5,4);
            map.Insert(new Water(),5,5);
            map.Insert(new Water(),5,6);
            map.Insert(new Tree(),5,9);
            map.Insert(new Tree(),3,9);
            map.Insert(new Tree(),8,3);
            map.Insert(new Tree(),2,5);
            map.Insert(new Tree(),1,4);
        }
            

        public void UpdateLayout(int x_old, int y_old , int x_new, int y_new){
            if(mapMatrix[x_new,y_new] is Empty){
                mapMatrix[x_new,y_new] = mapMatrix[x_old,y_old];
                mapMatrix[x_old,y_old] = new Empty();
            }
            else{}
            Print();
        }
     }
     public class JewelCollector{
        
        public static void Main() {   
            Map map = new Map(10,10);
            map.firstLevelLayout(map);

            Robot player = new Robot(map,0,0);


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
                    
                }
            } while (running);
        
        }  
     }

}
