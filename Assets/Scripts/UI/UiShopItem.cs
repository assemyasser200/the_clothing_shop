using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.U2D.Animation;

public class UiShopItem : MonoBehaviour
{
    public Image itemImage;
    public Text itemName;
    public Text itemPrice;
    public Button purchaseButton;

    [SerializeField] private SpriteLibraryAsset libraryAsset;

    public int Price{get; set;}
    public string Category{get; set;}
    public string Label{get; set;}
    public void SetItemUiData(ShopItemData data)
    {
        itemImage.sprite = libraryAsset.GetSprite(data.itemCategory.ToString(), data.itemLabel);
        itemName.text = data.itemName;
        itemPrice.text = data.price.ToString();

        Price = data.price;
        Label = data.itemLabel;
        Category = data.itemCategory.ToString();
    }
}
