namespace JewelCollector;

public class Robot : ItemMap{
    public override string ToString(){
        return "ME";
    }
    public int points { get; set; }
    public Map map ;
    public int x{ get; set; }
    public int y { get; set; }
    public List<Jewel> bag = new List<Jewel>();

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
        if(x+1 <= map.Width){
        if(map.mapMatrix[x+1,y] is Jewel jewel){
            this.points += jewel.Points;
            this.bag.Add(jewel);
            map.mapMatrix[x+1,y] = new Empty();  
        }}
        if( x-1 >= 0){
        if(map.mapMatrix[x-1,y] is Jewel jewel1){
            this.points += jewel1.Points;
            this.bag.Add(jewel1);
            map.mapMatrix[x-1,y] = new Empty();  
        }}
        if( y+1 <= map.Height){
        if(map.mapMatrix[x,y+1] is Jewel jewel2){
            this.points += jewel2.Points;
            this.bag.Add(jewel2);
            map.mapMatrix[x,y+1] = new Empty();  
        }}
        if( y-1 >= 0){
        if(map.mapMatrix[x,y-1] is Jewel jewel3){
            this.points += jewel3.Points;
            this.bag.Add(jewel3);
            map.mapMatrix[x,y-1] = new Empty();  
        }}

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
