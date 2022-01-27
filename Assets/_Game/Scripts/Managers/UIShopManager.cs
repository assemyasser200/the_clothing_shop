using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShopManager : MonoBehaviour
{
    [SerializeField] private ShopItemData[] shopItemsData;
    [Space]
    [SerializeField] private UiShopItem shopItem;
    [SerializeField] private Transform shopCanvas;
    [SerializeField] private Transform shopItemsPanel;
    [SerializeField] private PlayerInventoryManager inventoryManager;
    private IShopCustomer shopCustomer;
    private string[] labels;
    private string[] categoryNames;

    void Start()
    {
        for(int i = 0; i < shopItemsData.Length; i++)
        {
            if(!shopItemsData[i].OwnedByPlayer)
            {
                UiShopItem shopItemInstance = Instantiate(shopItem, shopItemsPanel, false);
                ShopItemData data =  shopItemsData[i];
                shopItemInstance.SetItemUiData(data);
                shopItemInstance.purchaseButton.onClick.AddListener(() =>
                    CheckItemPrice(shopItemInstance.Price, shopItemInstance.Category
                    , shopItemInstance.Label, data));
            }
        }
    }

    void CheckItemPrice(int price, string category, string label, ShopItemData data)
    {
        //Debug.Log(price +" , "+ category +" , "+ label);
        if(shopCustomer.CheckAvailableCoins(price))
        {
            AudioManager.instance.PlaySoundEffect("Buy");
            data.OwnedByPlayer = true;
            shopCustomer.BoughtItem(label, category);
            inventoryManager.AddItem(data);
        }
        else
        {
            AudioManager.instance.PlaySoundEffect("Error");
        }
        
    }

    public void StartShopInteraction(IShopCustomer shopCustomer)
    {
        this.shopCustomer = shopCustomer;
        shopCanvas.gameObject.SetActive(true);
    }

    public void ResetItemsOwnerShip()
    {
        for(int i = 0; i < shopItemsData.Length; i++)
        {
            shopItemsData[i].OwnedByPlayer = false;
        }
    }
}
