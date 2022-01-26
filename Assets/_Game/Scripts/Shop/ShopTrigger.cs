using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    [SerializeField] private UIShopManager shopManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        IShopCustomer shopCustomer = other.GetComponentInParent<IShopCustomer>();

        if(shopCustomer != null)
        {
            shopManager.StartShopInteraction(shopCustomer);
        }
    }
}
