using UnityEngine;
using System.Collections.Generic;

public class Chest : MonoBehaviour
{
    public List<Item> chestItems = new List<Item>();
    public int capacity = 4;

    public bool ChestHasSpace()
{
    if (capacity == int.MaxValue) return true;
    return chestItems.Count < capacity;
}

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

