namespace JewelCollector;

public class Robot : ItemMap{
    public override string ToString(){
        return "ME";
    }
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
    }
    public void MoveNorth(){
        map.UpdateLayout(x,y,x,y+1);
        this.y++;
    }
    public void MoveSouth(){
        map.UpdateLayout(x,y,x,y-1);
        this.y--;
    }
    public void MoveEast(){
        map.UpdateLayout(x,y,x-1,y);
        this.x--;
    }
    public void MoveWest(){
        map.UpdateLayout(x,y,x,y+1);
        this.x++;
    }
    
    

}
