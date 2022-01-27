using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Experimental.U2D.Animation;

public class UiInventoryItem : MonoBehaviour
{
    public Image itemImage;
    public TMP_Text itemName;
    public TMP_Text itemPrice;
    public Button sellButton;
    public Button equipButton;

    [SerializeField] private SpriteLibraryAsset libraryAsset;

    public int Price{get; set;}
    public string Category{get; set;}
    public string Label{get; set;}

    public void SetItemUiData(ShopItemData data)
    {
        itemImage.sprite = libraryAsset.GetSprite(data.itemCategory.ToString(), data.itemLabel);
        itemName.text = data.itemName;
        itemPrice.text = data.price.ToString();

        Price = data.SellToShopPrice;
        Label = data.itemLabel;
        Category = data.itemCategory.ToString();
    }
}
