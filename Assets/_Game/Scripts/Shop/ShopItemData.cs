using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopItemData", menuName = "Clothing Shop/Shop/ShopItem Data")]
public class ShopItemData : ScriptableObject
{
    public string itemName;
    public string itemLabel;
    public int price;
    public enum ItemCategory { Hair, Hat, MiddleFace, Body, LeftLeg, RightLeg }
    public ItemCategory itemCategory;

    public bool OwnedByPlayer { get; set; }
    public int SellToShopPrice { get; set; }
}
