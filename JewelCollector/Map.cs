namespace JewelCollector;

    abstract class ItemMap {
        string? symbol ;
        public string? Symbol {get;set;}

        public int x {get;set;}
        public int y {get;set;}

        public ItemMap(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class Empty : ItemMap {

        public Empty(int x, int y) : base(x, y)
        {

        }
     

        public override string ToString(){
            return "--";
        }

    }
    class Map {
        private ItemMap[,] map = new ItemMap[10,10];

        public Map(Dictionary<string,int[]> JewelPos ,  Dictionary<string,int[]> ObstaclePos) {
            

            for (int i = 0 ; i < map.GetLength(0);i++) {
                for(int j = 0 ; j < map.GetLength(1);j++){
                    if(JewelPos.ContainsValue(new int[]{i,j})){

                    }
                    
                    map[i,j] = new Empty(); 
                }
            }

        }

public void PopulateMap(List<ItemMap> ItemMap)
{

    foreach(ItemMap j in ItemMap)
    {

        map[j.x, j.y] = j;        
    }


}

// for each ArrayJewel {

}

        public void PrintMap() {

            for (int i = 0; i < map.GetLength(0); i++) {
                for (int j = 0; j < map.GetLength(1); j++) {
                    Console.Write(map[i, j]);
                    }
                     Console.Write("\n");
                } 

            }



    }


