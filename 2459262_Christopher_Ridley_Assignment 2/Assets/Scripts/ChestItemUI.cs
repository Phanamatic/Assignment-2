using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChestItemUI : MonoBehaviour
{
    public Item item;

    [SerializeField]
    private TextMeshProUGUI itemNameText;
    [SerializeField]
    private TextMeshProUGUI itemTypeText;
    [SerializeField]
    private TextMeshProUGUI itemCostText;
    [SerializeField]
    private Button moveToBackpackButton;

    public void Initialize()
    {
        itemNameText.text = item.name;
        itemTypeText.text = item.type;
        itemCostText.text = item.cost.ToString();
        moveToBackpackButton.onClick.AddListener(() => ChestUI.instance.MoveToBackpack(item));
    }
}