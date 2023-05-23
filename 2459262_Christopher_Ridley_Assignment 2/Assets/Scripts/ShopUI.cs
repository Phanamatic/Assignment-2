using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public Shop shop;
    public GameObject itemUIPrefab;
    public Transform itemUIParent; // This is a transform to hold the instantiated ItemUI prefabs

    public static ShopUI instance;

    // debugging - same error as seen in player and shop script
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of ShopUI found!");
            return;
        }

        instance = this;
    }

    // Method to update the shop's ui.
    public void UpdateShopUI()
    {
    // Starts by initially destroying all existing gameobjects (prefabs)
    foreach (Transform child in itemUIParent)
    {
        Destroy(child.gameObject);
    }

    // Fills up the items prefabs and populatesthe prefabs with the items data.
    foreach (Item item in shop.shopItems)
    {
        GameObject itemUIGameObject = Instantiate(itemUIPrefab, itemUIParent);
        ItemUI itemUI = itemUIGameObject.GetComponent<ItemUI>();
        itemUI.item = item;
        itemUI.Initialize();

        // Sets up the button to buy items
        itemUI.itemButton.onClick.RemoveAllListeners();
        itemUI.itemButton.onClick.AddListener(() => { Shop.instance.BuyItem(item); });
    }
    }
}