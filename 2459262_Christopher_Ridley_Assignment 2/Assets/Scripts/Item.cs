[System.Serializable]
public class Item
{
    public int id;
    public string name;
    public int cost;
    public string location;
    public string type;

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
