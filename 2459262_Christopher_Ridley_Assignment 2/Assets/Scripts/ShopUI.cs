using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public Shop shop;
    public GameObject itemUIPrefab;
    public Transform itemUIParent; // This is a transform to hold the instantiated ItemUI prefabs

    public static ShopUI instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of ShopUI found!");
            return;
        }

        instance = this;
    }

    public void UpdateShopUI()
    {
    // First, destroy any existing item UIs
    foreach (Transform child in itemUIParent)
    {
        Destroy(child.gameObject);
    }

    // Now, create a new item UI for each item in the shop
    foreach (Item item in shop.shopItems)
    {
        GameObject itemUIGameObject = Instantiate(itemUIPrefab, itemUIParent);
        ItemUI itemUI = itemUIGameObject.GetComponent<ItemUI>();
        itemUI.item = item;
        itemUI.Initialize();

        // Setup the button
        itemUI.itemButton.onClick.RemoveAllListeners();
        itemUI.itemButton.onClick.AddListener(() => { Shop.instance.BuyItem(item); });
    }
    }
}