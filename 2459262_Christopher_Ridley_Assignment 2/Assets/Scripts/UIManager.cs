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

    // Adds the listeners for the buttons to open and close the shop and chests. Starts the program with both Ui's hidden (inactive)    
    private void Start()
    {
        shopOpenButton.onClick.AddListener(() => { OpenShop(); });
        chestOpenButton.onClick.AddListener(() => { OpenChest(); });
        shopCloseButton.onClick.AddListener(() => { CloseShop(); });
        chestCloseButton.onClick.AddListener(() => { CloseChest(); });

        shopUI.SetActive(false);
        chestUI.SetActive(false);
    }

    // Updates the players currency balance and the players backpack balance
    private void Update()
    {
    backpackCapacityText.text = player.capacity.ToString();
    playerCurrencyText.text = player.currency.ToString();
    }

    // Method to carry out all the actions needed to open the shop
    private void OpenShop()
    {
        shop.OpenShop();
        chestUI.SetActive(false);
        shopUI.SetActive(true);
        ShopUI.instance.UpdateShopUI();
    }

    // method to carry out al the actions needed to open the chest
    private void OpenChest()
    {
        shopUI.SetActive(false);
        chestUI.SetActive(true);
    }

    // method to close the shop
    private void CloseShop()
    {
        shopUI.SetActive(false);
    }

    // method to close the chest
    private void CloseChest()
    {
        chestUI.SetActive(false);
    }
}
