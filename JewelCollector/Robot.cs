namespace JewelCollector;

public class Robot : ItemMap{
    public override string ToString(){
        return "ME";
    }
    public int points { get; set; }
    public Map map ;
    public int x{ get; set; }
    public int y { get; set; }
    List<Jewel>? bag;

    public Robot(Map map ,int x, int y){
        this.map = map;
        this.x = x;
        this.y = y;
        List<Jewel> bag = new List<Jewel>();
        map.Insert(this,x,y);
        map.Print();
    }
    public void MoveNorth(){
        map.UpdateLayout(x,y,x-1,y);
        this.x--;
    }
    public void MoveSouth(){
        map.UpdateLayout(x,y,x+1,y);
        this.x++;
    }
    public void MoveEast(){
        map.UpdateLayout(x,y,x,y+1);
        this.y++;
    }
    public void MoveWest(){
        map.UpdateLayout(x,y,x,y-1);
        this.y--;
    }
    public void CollectJewel(){
        if(map.mapMatrix[x+1,y] is Jewel){
            
        }
    }
    
    

}
