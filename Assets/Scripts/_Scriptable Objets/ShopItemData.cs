using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopItemData", menuName = "ShopItem Data")]
public class ShopItemData : ScriptableObject
{
    public string itemName;
    public string itemLabel;
    public int price;
    public enum ItemCategory{Head, Body, LeftLeg, RightLeg}
    public ItemCategory itemCategory; 
}
