using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShopManager : MonoBehaviour
{
    [SerializeField] private ShopItemData[] shopItemsData;
    [SerializeField] private UiShopItem shopItem;
    [SerializeField] private Transform shopCanvas;
    [SerializeField] private Transform shopItemsPanel;
    private IShopCustomer shopCustomer;
    private string[] labels;
    private string[] categoryNames;

    void Start()
    {
        for(int i = 0; i < shopItemsData.Length; i++)
        {
            UiShopItem shopItemInstance = Instantiate(shopItem, shopItemsPanel, false);
            shopItemInstance.SetItemUiData(shopItemsData[i]);
            shopItemInstance.purchaseButton.onClick.AddListener(() =>
                 CheckItemPrice(shopItemInstance.Price, shopItemInstance.Category
                , shopItemInstance.Label));
        }
    }

    void CheckItemPrice(int price, string category, string label)
    {
        //Debug.Log(price +" , "+ category +" , "+ label);

        shopCustomer.BoughtItem(label, category);
    }

    public void StartShopInteraction(IShopCustomer shopCustomer)
    {
        this.shopCustomer = shopCustomer;
        shopCanvas.gameObject.SetActive(true);
    }
}
