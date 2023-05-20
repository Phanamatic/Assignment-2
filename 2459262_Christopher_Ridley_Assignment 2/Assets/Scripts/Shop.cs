using UnityEngine;
using System.Collections.Generic;

public class Shop : MonoBehaviour
{
    public Player player;
    public List<Item> shopItems = new List<Item>();
    public int shopVisits = 0;

    private List<Item> possibleItems = new List<Item>()
    {
        new Item { name = "Sword", cost = 20, type = "Weapon" },
        new Item { name = "Bow", cost = 30, type = "Weapon" },
        new Item { name = "Apple", cost = 10, type = "Food" },
        new Item { name = "Water", cost = 10, type = "Drink" },
        new Item { name = "Coke", cost = 15, type = "Drink" },
        new Item { name = "Banana", cost = 5, type = "Food" },
        new Item { name = "Axe", cost = 30, type = "Weapon" },
        new Item { name = "Spear", cost = 15, type = "Weapon" },
        new Item { name = "Gun", cost = 80, type = "Weapon" },
        new Item { name = "Plaster", cost = 5, type = "Health" },
        new Item { name = "Bandage", cost = 20, type = "Health" },
        new Item { name = "Potion", cost = 40, type = "Health" }
    };

    private int nextItemIndex = 0;

    public static Shop instance;

    void Start()
    {
        // Populate the shop with 3 items
        for(int i = 0; i < 3; i++)
        {
            AddNewItem();
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Shop found!");
            return;
        }

        instance = this;
    }

    public void OpenShop()
    {
        shopVisits++;

        if (shopVisits % 5 == 0)
        {
            AddNewItem();
        }
        ShopUI.instance.UpdateShopUI();
    }

    private void AddNewItem()
    {
        if(nextItemIndex < possibleItems.Count && shopItems.Count < 12) // Add this condition
        {
            Item newItem = possibleItems[nextItemIndex];
            shopItems.Add(newItem);
            nextItemIndex++;
            ShopUI.instance.UpdateShopUI();
        }
    }

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
