﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopTrigger : MonoBehaviour
{
    [SerializeField] private UIShopManager shopManager;
    [SerializeField] private Animator shopKeeperAnimator;
    [SerializeField] private TMP_Text greetingText;
    private IShopCustomer shopCustomer;
    private PlayerStateListener playerStateListener;
    private bool checkForInteraction;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            shopCustomer = other.GetComponentInParent<IShopCustomer>();
            playerStateListener = other.GetComponentInParent<PlayerStateListener>();
            checkForInteraction = true;
            greetingText.transform.parent.gameObject.SetActive(true);
            StartCoroutine("popUpTime");
        }
    }

    /// <summary>
    /// Event listener
    /// </summary>
    public void OnShopClose()
    {
        playerStateListener.enabled = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        checkForInteraction = false;
    }

    IEnumerator popUpTime()
    {
        yield return new WaitForSeconds(2.5f);
        greetingText.transform.parent.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!this.checkForInteraction)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            SpeakWithShopKeeper();
        }
    }

    void SpeakWithShopKeeper()
    {
        playerStateListener.enabled = false;
        shopKeeperAnimator.Play("Greeting");
        StartCoroutine("WaitForGreeting");
    }

    IEnumerator WaitForGreeting()
    {
        yield return new WaitForSeconds(1.55f);
        shopKeeperAnimator.Play("Idle");
        OpenShopMenu();
        //TODO: start dialogue
    }

    /// <summary>
    /// Open Shop Menu On dialogue end
    /// </summary>
    void OpenShopMenu()
    {
        if(shopCustomer != null)
        {
            shopManager.StartShopInteraction(shopCustomer);
        }
    }
}
