[System.Serializable]
public class Item
{       
    //Each items unique properties
    public string name;
    public int cost;
    public string location;
    public string type;

    //Clone method used to buy items without removing them from the store
    public Item Clone()
    {
        return new Item
        {
            name = this.name,
            cost = this.cost,
            type = this.type
        };
    }
}
