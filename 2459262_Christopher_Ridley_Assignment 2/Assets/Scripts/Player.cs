using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int currency = 100;
    public List<Item> backpack = new List<Item>();
    public int capacity = 4;

    public void AddToBackpack(Item item)
    {
    if (backpack.Count < capacity)
    {
        backpack.Add(item);
        item.location = "backpack";
    }
    }

    public bool BackpackHasSpace()
    {
        return backpack.Count < capacity;
    }

    public void RemoveFromBackpack(Item item)
    {
        backpack.Remove(item);
        BackpackUI.instance.UpdateBackpackUI(); // Update UI when item removed
    }

    public bool CanAffordItem(Item item)
    {
        return currency >= item.cost;
    }

    public void BuyItem(Item item)
    {
        if (CanAffordItem(item) && BackpackHasSpace())
        {
            currency -= item.cost;
            AddToBackpack(item);
        }
    }

    public void SellItem(Item item)
    {
        currency += item.cost;
        RemoveFromBackpack(item);
    }

    public void UpgradeCapacity()
    {
    if (currency >= 10) 
    {
        currency -= 10;
        capacity += 2;
        Chest.instance.capacity = int.MaxValue; // Make chest capacity unlimited
        BackpackUI.instance.UpdateBackpackUI(); // Update UI when capacity upgraded
    }
    }

    public static Player instance;

    private void Awake()
    {
    if (instance != null)
    {
        Debug.LogWarning("More than one instance of Player found!");
        return;
    }

    instance = this;
    }
    
    public void UpgradeChestCapacity()
    {
    if (currency >= 40) 
    {
        currency -= 40;
        Chest.instance.capacity = int.MaxValue; // Make chest capacity unlimited
    }
    else
    {
        Debug.Log("Not enough currency to upgrade chest capacity!");
    }
    }
}
