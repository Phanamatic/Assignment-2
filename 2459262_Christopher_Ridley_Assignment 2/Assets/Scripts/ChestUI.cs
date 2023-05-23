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

    // Adds a executable to the chest upgrade button
    private void Start()
    {
    upgradeChestButton.onClick.AddListener(() => { UpgradeChest(); });
    }

    // Increases the chest capacity to maximum and then hides the etxt and button.
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

    // Debug - Same error seen in other scripts. Corrected
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of ChestUI found!");
            return;
        }

        instance = this;
    }

    // 
    public void UpdateChestUI()
    {   // First destroys all the initial objects
        foreach (Transform child in itemUIParent)
        {
            Destroy(child.gameObject);
        }
        // `sets up the new item prefabs
        foreach (Item item in chest.chestItems)
        {
            GameObject itemUIGameObject = Instantiate(itemUIPrefab, itemUIParent);
            ChestItemUI itemUI = itemUIGameObject.GetComponent<ChestItemUI>(); // Change to ChestItemUI
            itemUI.item = item;
            itemUI.Initialize();
        }
    }

    // Method used to move items between the chest and the backpack.
    public void MoveToBackpack(Item item)
    {
    // calls on the method to check the backpakc ahs space befor moving items
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
