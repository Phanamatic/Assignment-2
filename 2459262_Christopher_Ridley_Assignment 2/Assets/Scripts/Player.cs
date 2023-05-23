using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //Players starting currency
    public int currency = 100; 

    //Backpack list to hold items
    public List<Item> backpack = new List<Item>();

    //Players starting backpack capacity
    public int capacity = 4;

    //This methods adds items to the backpack. First checks the capacity and then adds the item.
    public void AddToBackpack(Item item)
    {
    if (backpack.Count < capacity)
    {
        backpack.Add(item);
        item.location = "backpack";
    }
    }

    //Methods checks to see the backpack has space.
    public bool BackpackHasSpace()
    {
        return backpack.Count < capacity;
    }

    //Metjod to remove items from the backpack. 
    public void RemoveFromBackpack(Item item)
    {
        backpack.Remove(item);
        BackpackUI.instance.UpdateBackpackUI(); // Calls on the update ui method
    }

    //Methods checks to see if the plyer can afford an item
    public bool CanAffordItem(Item item)
    {
        return currency >= item.cost;
    }

    //Buy Item Method. First check to see the player can afford the item and the backpack has space. Then subtract the cost and add the item to the backpack.
    public void BuyItem(Item item)
    {
    if (CanAffordItem(item) && BackpackHasSpace())
    {
        currency -= item.cost;
        AddToBackpack(item.Clone());
    }
    }

    //Sell Item method. Adds the cost of the item to the players total. Removes the item from the backpack.
    public void SellItem(Item item)
    {
        currency += item.cost;
        RemoveFromBackpack(item);
    }

    //upgrade backpack capacity. Adds 2 to the capcity and minuses 10 from the currency
    public void UpgradeCapacity()
    {
    if (currency >= 10) 
    {
        currency -= 10;
        capacity += 2;
        BackpackUI.instance.UpdateBackpackUI(); //Updates the players ui to see the capacity change
    }
    }

    //bug testing to fix script not executing correctly
    public static Player instance;

    private void Awake()
    {
    if (instance != null)
    {
        Debug.LogWarning("More than one instance of Player found!");  //bug testing, found unity bug that duplicates scripts in game objects for some reason
        return;
    }

    instance = this;
    }
    
    //method to upgrade the chest to have unlimited space for 40 currency
    public void UpgradeChestCapacity()
    {
    if (currency >= 40) 
    {
        currency -= 40;
        Chest.instance.capacity = int.MaxValue; 
    }
    else
    {
        Debug.Log("Not enough currency to upgrade chest capacity!"); //bug testing 
    }
    }
}
