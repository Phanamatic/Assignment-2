using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro; // You need to add this line at the top of your script

public class ItemUI : MonoBehaviour
{
    public Item item;
    public TextMeshProUGUI itemName; // Changed from Text to TextMeshProUGUI
    public TextMeshProUGUI itemCost; // Changed from Text to TextMeshProUGUI
    public Button itemButton;
    public TextMeshProUGUI itemType;
    

    public void Initialize()
    {
    Debug.Log("Item: " + item);
    Debug.Log("itemName: " + itemName);
    Debug.Log("itemCost: " + itemCost);
    Debug.Log("itemType: " + itemType);

    itemName.text = item.name;
    itemCost.text = item.cost.ToString();
    itemType.text = item.type;
    }
}
