using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro; // Needed for TExtmeshpro

public class ItemUI : MonoBehaviour
{
    public Item item;
    public TextMeshProUGUI itemName; // Changed text to TextMeshPro
    public TextMeshProUGUI itemCost; 
    public Button itemButton;
    public TextMeshProUGUI itemType;
    

    public void Initialize()
    {
    Debug.Log("Item: " + item);
    Debug.Log("itemName: " + itemName);
    Debug.Log("itemCost: " + itemCost);
    Debug.Log("itemType: " + itemType);

    // Initialize method populates the UI of the item prefabs
    itemName.text = item.name;
    itemCost.text = item.cost.ToString();
    itemType.text = item.type;
    }
}
