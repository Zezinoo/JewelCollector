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
        if (isAllowed(x-1,y)){
        map.UpdateLayout(x,y,x-1,y);
        this.x--;
        }
    }
    public void MoveSouth(){
        if (isAllowed(x+1,y)){
        map.UpdateLayout(x,y,x+1,y);
        this.x++;
        }
    }
    public void MoveEast(){
        if (isAllowed(x,y+1)){
        map.UpdateLayout(x,y,x,y+1);
        this.y++;
        }
    }
    public void MoveWest(){
        if (isAllowed(x,y-1)){
        map.UpdateLayout(x,y,x,y-1);
        this.y--;
        }
    }
    public void CollectJewel(){
        if(map.mapMatrix[x+1,y] is Jewel){
            
        }
    }

    public bool isAllowed(int x, int y ){
        if (map.mapMatrix[x,y] is Empty){
            return true; 
        } 
        else{
            return false;
        }
    }
    
    

}
