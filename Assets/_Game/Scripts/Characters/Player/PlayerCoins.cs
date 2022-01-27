using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoins : MonoBehaviour, IInterActable
{
    private int playerCoins;
    [Tooltip("Initial coins amount the player will start the game with")]
    [SerializeField] private int initialCoinsAmount;
    [SerializeField] private int[] coinRewards;
    [Space]
    [SerializeField] private IntegerEvent updateCoinsUI;

    public void InitializePlayerCoins()
    {
        playerCoins = initialCoinsAmount;
    }

    public int CalculateRewardedCoins()
    {
        int coins = coinRewards[Random.Range(0, coinRewards.Length)];
        playerCoins += coins;
        updateCoinsUI.Invoke(playerCoins);
        return coins;
    }
}
