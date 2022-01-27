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

    [SerializeField] private SpriteLibraryAsset libraryAsset;

    public int Price{get; set;}

    public void SetItemUiData(ShopItemData data)
    {
        itemImage.sprite = libraryAsset.GetSprite(data.itemCategory.ToString(), data.itemLabel);
        itemName.text = data.itemName;
        itemPrice.text = data.SellToShopPrice.ToString();
        Price = data.SellToShopPrice;
    }
}
