using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Player player;
    public Shop shop;
    public Chest chest;

    public GameObject shopUI;
    public GameObject backpackUI;
    public GameObject chestUI;

    public Button shopOpenButton;
    public Button chestOpenButton;
    public Button shopCloseButton;
    public Button chestCloseButton;


    public TextMeshProUGUI backpackCapacityText; 
    public TextMeshProUGUI playerCurrencyText;

    private void Start()
    {
        shopOpenButton.onClick.AddListener(() => { OpenShop(); });
        chestOpenButton.onClick.AddListener(() => { OpenChest(); });
        shopCloseButton.onClick.AddListener(() => { CloseShop(); });
        chestCloseButton.onClick.AddListener(() => { CloseChest(); });

        shopUI.SetActive(false);
        chestUI.SetActive(false);
    }

    private void Update()
    {
        if(chest.chestItems.Count > 0)
        {
        foreach(Item item in chest.chestItems)
        {
     //   chestText.text += item.name + "\n";
        }
        }
else
{
  //  chestText.text += "Empty";
}
    backpackCapacityText.text = player.capacity.ToString();
    playerCurrencyText.text = player.currency.ToString();
    }

    private void OpenShop()
    {
        shop.OpenShop();
        chestUI.SetActive(false);
        shopUI.SetActive(true);
        ShopUI.instance.UpdateShopUI();
    }

    private void OpenChest()
    {
        shopUI.SetActive(false);
        chestUI.SetActive(true);
    }

    private void CloseShop()
    {
        shopUI.SetActive(false);
    }

    private void CloseChest()
    {
        chestUI.SetActive(false);
    }
}
