namespace JewelCollector;

public class Tree : Obstacle, Rechargeable {
        public override string ToString(){
        Console.ForegroundColor= ConsoleColor.White;
        return "$$ ";
        }
        public void Recharge(Robot player){
            player.energy = player.energy +3;
    }
}
