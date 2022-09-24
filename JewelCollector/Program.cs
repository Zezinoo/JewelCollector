namespace JewelCollector {

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
                
        void Print() {
            for (int i = 0; i < mapMatrix.GetLength(0); i++) {
                for (int j = 0; j < mapMatrix.GetLength(1); j++) {
                Console.Write(mapMatrix[i, j]);
                }
                Console.Write("\n");
            }
        }

        void Insert (ItemMap Item , int i, int j){
            mapMatrix[i,j] = Item;
        }
     
        public static void Main() {   
        
        Map map = new Map(10,10);
        map.Insert(new Red(),0,0);
        map.Print();
        
        }         
     }

    }
