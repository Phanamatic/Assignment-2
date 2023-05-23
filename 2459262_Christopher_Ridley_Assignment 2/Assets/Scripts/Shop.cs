using UnityEngine;
using System.Collections.Generic;

public class Shop : MonoBehaviour
{
    public Player player;

    // Lists holding the shop's items
    public List<Item> shopItems = new List<Item>();

    // Variable to keep track of each visit to the shop
    public int shopVisits = 0;

    // All the items data
    private List<Item> possibleItems = new List<Item>()
    {
        new Item { name = "Sword", cost = 10, type = "Weapon" },
        new Item { name = "Bow", cost = 15, type = "Weapon" },
        new Item { name = "Apple", cost = 5, type = "Food" },
        new Item { name = "Water", cost = 5, type = "Drink" },
        new Item { name = "Coke", cost = 10, type = "Drink" },
        new Item { name = "Banana", cost = 5, type = "Food" },
        new Item { name = "Axe", cost = 15, type = "Weapon" },
        new Item { name = "Spear", cost = 10, type = "Weapon" },
        new Item { name = "Gun", cost = 40, type = "Weapon" },
        new Item { name = "Plaster", cost = 5, type = "Health" },
        new Item { name = "Bandage", cost = 10, type = "Health" },
        new Item { name = "Potion", cost = 20, type = "Health" }
    };


    private int nextItemIndex = 0;

    public static Shop instance;

    // Initially populates the shop with 3 items
    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            AddNewItem();
        }
    }

    // debugging - same error as seen in player script
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Shop found!");
            return;
        }

        instance = this;
    }

    // Adds a visit each time the shop is opened. Adds new item every 3 opens.
    public void OpenShop()
    {
        shopVisits++;

        if (shopVisits % 3 == 0)
        {
            AddNewItem();
        }
        ShopUI.instance.UpdateShopUI();
    }

    // Methid to add a new item. Adds the next item after every 2 visits.
    private void AddNewItem()
    {
        if(nextItemIndex < possibleItems.Count && shopItems.Count < 12) // Stops adding items after all 12 have been added
        {
            Item newItem = possibleItems[nextItemIndex];
            shopItems.Add(newItem);
            nextItemIndex++;
            ShopUI.instance.UpdateShopUI();
        }
    }

    // Method to Buy Items. Checks if the player has enough currency, then checks the backpack capacity. 
    public void BuyItem(Item item)
    {
    if (player.CanAffordItem(item) && player.BackpackHasSpace())
    {
        player.BuyItem(item);
        ShopUI.instance.UpdateShopUI();
        BackpackUI.instance.UpdateBackpackUI(); 
    }
    }
}
