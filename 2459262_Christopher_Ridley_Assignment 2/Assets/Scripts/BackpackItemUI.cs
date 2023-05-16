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

    private void Start()
    {
        sellButton.onClick.AddListener(() => { BackpackUI.instance.SellItem(item); });
        moveToChestButton.onClick.AddListener(() => { BackpackUI.instance.MoveToChest(item); });
    }

    public void Initialize()
    {
        itemName.text = item.name;
        itemCost.text = item.cost.ToString();
        itemType.text = item.type;
    }
}