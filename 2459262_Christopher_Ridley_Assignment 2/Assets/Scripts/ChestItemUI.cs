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

    // Initialize method called to populate the item prefabs ui. Also creates the executable for the prefab button (move to backpack)
    public void Initialize()
    {
        itemNameText.text = item.name;
        itemTypeText.text = item.type;
        itemCostText.text = item.cost.ToString();
        moveToBackpackButton.onClick.AddListener(() => ChestUI.instance.MoveToBackpack(item));
    }
}