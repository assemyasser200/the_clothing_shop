using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
using System.Linq;

public class ShopManager : MonoBehaviour
{

    [SerializeField] private SpriteLibraryAsset libraryAsset;
    [SerializeField] private ShopItemData[] shopItemsData;
    [SerializeField] private UiShopItem shopItem;
    [SerializeField] private Transform shopItemsPanel;
    private IShopCustomer shopCustomer;
    private string[] labels;
    private string[] categoryNames;

    void Start()
    {
        // categoryNames = libraryAsset.GetCategoryNames().ToArray(); 

        // for(int i = 0; i < categoryNames.Length; i++)
        // {
        //     labels = libraryAsset.GetCategoryLabelNames(categoryNames[i]).ToArray();
        // }

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
        Debug.Log(price +" , "+ category);
        Debug.Log(shopCustomer);
        shopCustomer.BoughtItem(label, category);
    }
}
