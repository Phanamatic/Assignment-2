using UnityEngine;
using System.Collections.Generic;

public class Chest : MonoBehaviour
{
    // chest list holds items in teh chest
    public List<Item> chestItems = new List<Item>();

    //Sets initial chest capacity for player
    public int capacity = 4;

    // method to check if the chest has space before moving items
    public bool ChestHasSpace()
{
    if (capacity == int.MaxValue) return true;
    return chestItems.Count < capacity;
}

    // debugging - in other scripts - fixed

    public static Chest instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Chest found!");
            return;
        }

        instance = this;
    }
}

