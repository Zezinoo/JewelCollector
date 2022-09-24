namespace JewelCollector;

    public class Jewel{
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

