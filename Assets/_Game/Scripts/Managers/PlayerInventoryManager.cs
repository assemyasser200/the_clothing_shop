using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryManager : MonoBehaviour
{
    private List<ShopItemData> boughtItems = new List<ShopItemData>();
    private PlayerOutfitSwapController playerOutfitSwap;
    [SerializeField] private UiInventoryItem inventoryItem;
    [SerializeField] private Transform inventoryCanvas;
    [SerializeField] private Transform inventoryItemsPanel;

    void OnEnable()
    {
        DisplayItems();
    }

    void Start()
    {
        
    }

    public void SetPlayer(PlayerOutfitSwapController playerOutfitSwap)
    {
        this.playerOutfitSwap = playerOutfitSwap;
    }

    public void AddItem(ShopItemData data)
    {
        data.SellToShopPrice = data.price + Random.Range(35, 66);
        boughtItems.Add(data);
    }

    void DisplayItems()
    {
        for(int i = 0; i < boughtItems.Count; i++)
        {
            UiInventoryItem inventoryItemInstance = Instantiate(inventoryItem, inventoryItemsPanel, false);
            ShopItemData data = boughtItems[i];
            inventoryItemInstance.SetItemUiData(data);
            // inventoryItemInstance.sellButton.onClick.AddListener(() =>
            //     EquipItem(inventoryItemInstance.Category, inventoryItemInstance.Label));
        }
    }
}
