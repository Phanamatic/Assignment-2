using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class BackpackUI : MonoBehaviour
{
    public Player player;
    public Chest chest;
    public GameObject itemUIPrefab;
    public Transform itemUIParent;

    public static BackpackUI instance;

    public Button upgradeButton;

    // debug - seen in most scripts - fixed
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of BackpackUI found!");
            return;
        }

        instance = this;
    }

    // Creates a listener to execute code when the upgrade button is pressed 
    private void Start()
    {
        upgradeButton.onClick.AddListener(() => { UpgradeBackpack(); });
    }

    public void UpdateBackpackUI()
    {
        foreach (Transform child in itemUIParent)
        {
            Destroy(child.gameObject);
        }

        foreach (Item item in player.backpack)
        {
            GameObject itemUIGameObject = Instantiate(itemUIPrefab, itemUIParent);
            BackpackItemUI itemUI = itemUIGameObject.GetComponent<BackpackItemUI>();
            itemUI.item = item;
            itemUI.Initialize();
        }
    }

    // Method to move items from the backapck to the chest. Checks if there is capacity. 
    public void MoveToChest(Item item)
{
    if (chest.ChestHasSpace())
    {
        player.backpack.Remove(item);
        chest.chestItems.Add(item);
        item.location = "chest";
        UpdateBackpackUI();
        ChestUI.instance.UpdateChestUI();
    }
    else
    {
        Debug.Log("Chest is full!");
    }
}

    // Method to sell items
    public void SellItem(Item item)
    {
        player.currency += item.cost; // Adds the item's cost to the player's currency
        player.backpack.Remove(item); // Removes the item from the backpack
        UpdateBackpackUI(); // Updates the UI
    }

    // Method calls on other method to upgrade the backpacks capacity
    public void UpgradeBackpack()
    {
        player.UpgradeCapacity();
    }
}

