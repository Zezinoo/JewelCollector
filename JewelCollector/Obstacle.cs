namespace JewelCollector;

public abstract class Obstacle : ItemMap 
{

}

public class Empty : Obstacle {
    public override string ToString(){
        return "Empty ";
    }
}
