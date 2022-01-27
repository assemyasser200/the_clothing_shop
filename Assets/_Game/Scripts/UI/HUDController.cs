using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;
     
    public void UpdateRewardedCoins(int value)
    {
        coinsText.text = value.ToString();
    }
}
