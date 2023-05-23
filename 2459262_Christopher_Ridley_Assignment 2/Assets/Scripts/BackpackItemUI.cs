using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BackpackItemUI : MonoBehaviour
{
    public Item item;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemCost;
    public TextMeshProUGUI itemType;
    public Button sellButton;
    public Button moveToChestButton;

    // Creates the executable codes for the sell and move buttons for the backpack item prefabs
    private void Start()
    {
        sellButton.onClick.AddListener(() => { BackpackUI.instance.SellItem(item); });
        moveToChestButton.onClick.AddListener(() => { BackpackUI.instance.MoveToChest(item); });
    }

    // Initialize method, called to populate prefabs ui
    public void Initialize()
    {
        itemName.text = item.name;
        itemCost.text = item.cost.ToString();
        itemType.text = item.type;
    }
}