namespace JewelCollector;
/// <summary>
/// Interface that defines generic method for recharging objects
/// </summary>
public interface Rechargeable
{
    /// <summary>
    /// Generic method to recharge player
    /// </summary>
    /// <param name="r">Current player</param>
    public void Recharge(Robot r);
}
