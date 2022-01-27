using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryManager : MonoBehaviour
{
    private List<ShopItemData> boughtItems = new List<ShopItemData>();
    private PlayerOutfitSwapController playerOutfitSwap;
    [SerializeField] private UiInventoryItem inventoryItem;
    [SerializeField] private Transform inventoryItemsPanel;

    public void SetPlayer(PlayerOutfitSwapController playerOutfitSwap)
    {
        this.playerOutfitSwap = playerOutfitSwap;
    }

    public void AddItem(ShopItemData data)
    {
        data.SellToShopPrice = data.price + Random.Range(35, 66);
        boughtItems.Add(data);
    }

    public void OnOpenInventory()
    {
        if(boughtItems.Count <= 0)
        {
            return;
        }

        for(int i = 0; i < boughtItems.Count; i++)
        {
            UiInventoryItem inventoryItemInstance = Instantiate(inventoryItem, inventoryItemsPanel, false);
            ShopItemData data = boughtItems[i];
            inventoryItemInstance.SetItemUiData(data);
            inventoryItemInstance.equipButton.onClick.AddListener(() =>
                EquipItem(inventoryItemInstance.Category, inventoryItemInstance.Label));
        }
    }

    void EquipItem(string category, string label)
    {
        this.playerOutfitSwap.BoughtItem(label, category);
    }
}
