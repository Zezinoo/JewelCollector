namespace JewelCollector;
/// <summary>
/// Class that represents the map where the game is played
/// </summary>
public class Map {
        /// <summary>
        /// Matrix of ItemMaps that represents the game map
        /// </summary>
        public ItemMap[,] mapMatrix ; 
        /// <summary>
        /// Width of game map
        /// </summary>
        /// <value>Defined on constructor</value>
        public int Width { get; private set; }
        /// <summary>
        /// Height of game map
        /// </summary>
        /// <value>Defined on constructor</value>
        public int Height { get; private set; }
        /// <summary>
        /// Map constructor.Initializes an empty map
        /// </summary>
        /// <param name="width">Defined based on level</param>
        /// <param name="height">Defined based on level</param>
        public Map(int width, int height) { 
            Width = width; Height = height;
            mapMatrix = new ItemMap[width, height];
            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++) {
                    mapMatrix[i,j] = new Empty();
                 }
            }

        }
                
        /// <summary>
        /// Print method to show map on terminal
        /// </summary>
        public void Print() {
            for (int i = 0; i < mapMatrix.GetLength(0); i++) {
                for (int j = 0; j < mapMatrix.GetLength(1); j++) {
                Console.Write(mapMatrix[i, j]);
                }
                Console.Write("\n");
            }
        }
        /// <summary>
        /// Method to insert ItemMap objects on map positions
        /// </summary>
        /// <param name="Item">Type of object to be inserted</param>
        /// <param name="i">y-position of the object to be inserted</param>
        /// <param name="j">x-position of the object to be inserted</param>
        public void Insert (ItemMap Item , int i, int j){
            mapMatrix[i,j] = Item;
        }
        /// <summary>
        /// Initializes the map with a fixed layout for the first level
        /// </summary>
        /// <param name="map">Current Map Object</param>
        public void firstLevelLayout (Map map){
            map.Insert(new Red(),1, 9);
            map.Insert(new Red(),8,8);
            map.Insert(new Green(),9,1);
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
        /// <summary>
        /// Initializes the map with a random layout for all levels except level 1
        /// </summary>
        /// <param name="map">Current map object</param>
        /// <param name="jewel_numbers">Total number for all jewels , based on a fixed proportion</param>
        /// <param name="water_numbers">Total number  for water obstacles , based on a fixed proportion</param>
        /// <param name="tree_numbers">Total number for tree obstacles , based on a fixed proportion</param>
        public void randomLevelLayout (Map map , int jewel_numbers , int water_numbers , int tree_numbers){
            Random random = new Random();
            for(int x = 0; x <jewel_numbers+2; x++){ //Put more blue jewels to make the game easier
                int xRandom = random.Next(0,map.Width);
                int yRandom = random.Next(0,map.Height);
                this.Insert(new Blue(), xRandom, yRandom);
            }
            for(int x = 0; x <jewel_numbers; x++){
                int xRandom = random.Next(0,map.Width);
                int yRandom = random.Next(0,map.Height);
                this.Insert(new Green(), xRandom, yRandom);
            }
            for(int x = 0; x <jewel_numbers; x++){
                int xRandom = random.Next(0,map.Width);
                int yRandom = random.Next(0,map.Height);
                this.Insert(new Red(), xRandom, yRandom);
            }
            for(int x = 0; x <tree_numbers; x++){
                int xRandom = random.Next(0,map.Width);
                int yRandom = random.Next(0,map.Height);
                this.Insert(new Tree(), xRandom, yRandom);
            }
            for(int x = 0; x <water_numbers; x++){
                int xRandom = random.Next(0,map.Width);
                int yRandom = random.Next(0,map.Height);
                this.Insert(new Water(), xRandom, yRandom);
            }

            for(int x = 0; x < jewel_numbers-1; x++){
                int xRandom = random.Next(0,map.Width);
                int yRandom = random.Next(0,map.Height);
                this.Insert(new Radioactive(), xRandom, yRandom);
            }
        }
        /// <summary>
        /// Method to update the map Layout after each robot movement. Clears terminal before every instance
        /// </summary>
        /// <param name="player">Current player object</param>
        /// <param name="x_old">Old x position</param>
        /// <param name="y_old">Old y position</param>
        /// <param name="x_new">New x position</param>
        /// <param name="y_new">New y position</param>
        public void UpdateLayout(Robot player , int x_old, int y_old , int x_new, int y_new){
            
            Console.Clear();
            if(mapMatrix[x_new,y_new] is Empty){
                mapMatrix[x_new,y_new] = mapMatrix[x_old,y_old];
                mapMatrix[x_old,y_old] = new Empty();
            }
            if(mapMatrix[x_new,y_new] is Radioactive){
                player.energy = player.energy - 30;
                mapMatrix[x_new,y_new] = mapMatrix[x_old,y_old];
                mapMatrix[x_old,y_old] = new Empty();
                Console.WriteLine("Ran into Radioactive");
            }

            else{}
            Print();
        }
        /// <summary>
        /// Method to check if no Jewels are left on current map.
        /// </summary>
        /// <param name="map">Current map</param>
        /// <returns>Returns true if there are no Jewels, false otherwise</returns>
        public bool noJewelsLeft(Map map){
            for (int i = 0; i < mapMatrix.GetLength(0); i++) {
                for (int j = 0; j < mapMatrix.GetLength(1); j++) {
                    if (mapMatrix[i, j] is Jewel ){
                        return false;    
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Updates item quantities based on level
        /// </summary>
        /// <param name="map">Current map</param>
        /// <returns>Returns an array with the quantities of Jewels and Obstacles</returns>
        public int[] newItemMapQuantity(Map map){
            double jewel_proportion = 2.0/100.0;
            double water_proportion = 7.0/100.0;
            double tree_proportion = 5.0/100.0;

            int jewel_numbers =(int) Math.Round(jewel_proportion*(map.Width)*(map.Width)); 

            int water_numbers = (int)Math.Round(water_proportion*(map.Width)*(map.Width));

            int tree_numbers = (int)Math.Round(tree_proportion*(map.Width)*(map.Width));

            int[] new_numbers = {jewel_numbers,water_numbers,tree_numbers};

            return new_numbers;
        }
     }
