namespace JewelCollector {
    class Jewel{
        public string Color { get; set; }
        public int Point { get; set; }

        public Jewel(string color){

            Color = color;
            Point = color switch  {
                "red" => 100,
                "blue" => 200,
                "green" => 300,
                _ => 0
            };
        }
    }

    abstract class ItemMap{

    }

    abstract class Obstacle : ItemMap
    {

    }

    class Water : Obstacle
    {

    }

    class Red : Jewel {

        public Red(string s): base(s)
        {
            
        }

    }

    class Blue : Jewel {

    class Map {
        public int Width { get; set; }
        public int Height { get; set; }

        private ItemMap[,] Matrix = new ItemMap[10,10];
    }
}