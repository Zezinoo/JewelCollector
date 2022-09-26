namespace JewelCollector;
/// <summary>
/// Class that represents the player on the map
/// </summary>
public class Robot : ItemMap{
    /// <summary>
    /// Overrides To string method so correct symbol is printed on map
    /// </summary>
    /// <returns>Robot symbol</returns>
    public override string ToString(){
        Console.ForegroundColor= ConsoleColor.White;
        return "ME ";
    }
    /// <summary>
    /// Robot points
    /// </summary>
    /// <value>Defined on constructor</value>
    public int points { get; set; }

    /// <summary>
    /// Robot energy
    /// </summary>
    /// <value>Defined on constructor</value>
    public int energy { get; set; }
    private Map map ;
    /// <summary>
    /// x-axis of the map
    /// </summary>
    /// <value>Defined on constructor</value>
    public int x{ get; set; }
    /// <summary>
    /// y-axis of the map
    /// </summary>
    /// <value>Defined on constructor</value>
    public int y { get; set; }
    /// <summary>
    /// Creates robot bag;
    /// </summary>
    /// <typeparam name="Jewel">Jewel Object</typeparam>
    /// <returns>Returns empty Jewel Collection</returns>
    public List<Jewel> bag = new List<Jewel>();
    /// <summary>
    /// Robot Object Constructor, also inserts the robot in the map.
    /// </summary>
    /// <param name="map">Map Object</param>
    /// <param name="x">y-axis of the map</param>
    /// <param name="y">x-axis of the map</param>
    public Robot(Map map ,int x, int y){
        this.energy = 5;
        this.map = map;
        this.x = x;
        this.y = y;
        List<Jewel> bag = new List<Jewel>();
        map.Insert(this,x,y);
        map.Print();
    }
    /// <summary>
    /// This method defines the North movement of the robot, first checking if the north position is allowed, if it is calls the UpdateLayout method and updates energy and position
    /// </summary>
    public void MoveNorth(){
        if (isAllowed(x-1,y)){
        map.UpdateLayout(this,x,y,x-1,y);
        this.x--;
        this.energy--;
        }
    }
    /// <summary>
    /// This method defines the South movement of the robot, first checking if the south position is allowed, if it is calls the UpdateLayout method and updates energy and position
    /// </summary>
    public void MoveSouth(){
        if (isAllowed(x+1,y)){
        map.UpdateLayout(this,x,y,x+1,y);
        this.x++;
        this.energy--;
        }
    }
    /// <summary>
    ///This method defines the East movement of the robot, first checking if the  position is allowed, if it is calls the UpdateLayout method and updates energy and position 
    /// </summary>
    public void MoveEast(){
        if (isAllowed(x,y+1)){
        map.UpdateLayout(this,x,y,x,y+1);
        this.y++;
        this.energy--;
        }
    }
    /// <summary>
    /// This method defines the West movement of the robot, first checking if the west position is allowed, if it is calls the UpdateLayout method and updates energy and position
    /// </summary>
    public void MoveWest(){
        if (isAllowed(x,y-1)){
        map.UpdateLayout(this,x,y,x,y-1);
        this.y--;
        this.energy--;
        }
    }
    /// <summary>
    /// This methods checks for Jewels on adjacent positions , that is , on a cross shape, and collects it to the bag.
    /// </summary>
    public void CollectJewel(){
        if(x+1 < map.Width){
        if(map.mapMatrix[x+1,y] is Jewel jewel){
            this.points += jewel.Points;
            this.bag.Add(jewel);
            if(jewel is Rechargeable r){r.Recharge(this);}
            map.mapMatrix[x+1,y] = new Empty();  
        }}
        if( x-1 >= 0){
        if(map.mapMatrix[x-1,y] is Jewel jewel1){
            this.points += jewel1.Points;
            this.bag.Add(jewel1);
            if(jewel1 is Rechargeable r){r.Recharge(this);}
            map.mapMatrix[x-1,y] = new Empty();  
        }}
        if( y+1 < map.Height){
        if(map.mapMatrix[x,y+1] is Jewel jewel2){
            this.points += jewel2.Points;
            this.bag.Add(jewel2);
            if(jewel2 is Rechargeable r){r.Recharge(this);}
            map.mapMatrix[x,y+1] = new Empty();  
        }}
        if( y-1 >= 0){
        if(map.mapMatrix[x,y-1] is Jewel jewel3){
            this.points += jewel3.Points;
            this.bag.Add(jewel3);
            if(jewel3 is Rechargeable r){r.Recharge(this);}
            map.mapMatrix[x,y-1] = new Empty();  
        }}

    }
    /// <summary>
    /// This method checks adjacent positions of the matrix for presence of rechargeble objects. If there are any, applies Recharge method to the player.
    /// </summary>
    public void GetRechargeable() {
        if(x+1 < map.Width){
        if(map.mapMatrix[x+1,y] is Rechargeable r){
            r.Recharge(this);
            map.mapMatrix[x+1,y] = new Empty();  
        }}
        if( x-1 >= 0){
        if(map.mapMatrix[x-1,y] is Rechargeable r1){
            r1.Recharge(this);
            map.mapMatrix[x-1,y] = new Empty();    
        }}
        if( y+1 < map.Height){
        if(map.mapMatrix[x,y+1] is Rechargeable r2){
            r2.Recharge(this);
            map.mapMatrix[x,y+1] = new Empty();    
        }}
        if( y-1 >= 0){
        if(map.mapMatrix[x,y-1] is Rechargeable r3){
            r3.Recharge(this);
            map.mapMatrix[x,y-1] = new Empty();   
        }}
    }

    /// <summary>
    /// Checks if adjacent positions are an object of Class Radioactive
    /// </summary>
    public void checkRadioctive(){
        if(x+1 < map.Width){
        if(map.mapMatrix[x+1,y] is Radioactive r){
            this.energy = this.energy -10; 
        }}
        if( x-1 >= 0){
        if(map.mapMatrix[x-1,y] is Radioactive r1){ 
            this.energy = this.energy -10;   
        }}
        if( y+1 < map.Height){
        if(map.mapMatrix[x,y+1] is Radioactive r2){
            this.energy = this.energy -10;    
        }}
        if( y-1 >= 0){
        if(map.mapMatrix[x,y-1] is Radioactive r3){
            this.energy = this.energy -10;   
        }}
    }
    /// <summary>
    /// This method checks if a positon [x,y] in the map matrix can be occupied by the player.
    /// </summary>
    /// <param name="x">y-axis of the map</param>
    /// <param name="y">x-axis of the map</param>
    /// <returns>Returns a true boolean if the position can be occupied, false otherwise.</returns>
    private bool isAllowed(int x, int y ){
        if (! (x >= 0 && x<map.Width && y>=0 && y<map.Width)){return false;}
        if (map.mapMatrix[x,y] is Empty || map.mapMatrix[x,y] is Radioactive){
            return true; 
        } 
        else{
            return false;
        }
    }

    
    /// <summary>
    /// This method concatenates CollectJewel and GetRechargeble methods for better event handling. 
    /// </summary>
    public void Collect(){
        this.CollectJewel();
        this.GetRechargeable();
    }
    
}
