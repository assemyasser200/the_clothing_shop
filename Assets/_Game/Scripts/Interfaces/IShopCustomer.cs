﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShopCustomer
{
    void BoughtItem(string label, string Category);
    bool CheckAvailableCoins(int price);
}
