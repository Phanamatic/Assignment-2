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

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of BackpackUI found!");
            return;
        }

        instance = this;
    }

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

    public void SellItem(Item item)
    {
        player.currency += item.cost; // Add the item cost to the player's currency
        player.backpack.Remove(item); // Remove the item from the backpack
        UpdateBackpackUI(); // Update the UI
    }

    public void UpgradeBackpack()
    {
        player.UpgradeCapacity();
    }
}

