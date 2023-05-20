using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class ChestUI : MonoBehaviour
{
    public Chest chest;
    public Player player;
    public GameObject itemUIPrefab;
    public Transform itemUIParent;

    public static ChestUI instance;

    public TextMeshProUGUI chestUpgradeText1;
    public TextMeshProUGUI chestUpgradeText2;

    public Button upgradeChestButton;

    private void Start()
    {
    upgradeChestButton.onClick.AddListener(() => { UpgradeChest(); });
    }

    public void UpgradeChest()
    {
    player.UpgradeChestCapacity();
    if (Chest.instance.capacity == int.MaxValue) 
    {
        upgradeChestButton.gameObject.SetActive(false);
        chestUpgradeText1.gameObject.SetActive(false);
        chestUpgradeText2.gameObject.SetActive(false);
    }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of ChestUI found!");
            return;
        }

        instance = this;
    }

    public void UpdateChestUI()
    {
        foreach (Transform child in itemUIParent)
        {
            Destroy(child.gameObject);
        }

        foreach (Item item in chest.chestItems)
        {
            GameObject itemUIGameObject = Instantiate(itemUIPrefab, itemUIParent);
            ChestItemUI itemUI = itemUIGameObject.GetComponent<ChestItemUI>(); // Change to ChestItemUI
            itemUI.item = item;
            itemUI.Initialize();
        }
    }

    public void MoveToBackpack(Item item)
{
    // Only need to check if the player's backpack has room before moving the item.
    if (player.BackpackHasSpace())
    {
        chest.chestItems.Remove(item);
        player.AddToBackpack(item);
        UpdateChestUI();
        BackpackUI.instance.UpdateBackpackUI();
    }
    else
    {
        Debug.Log("Backpack is full!");
    }
}


    
}
