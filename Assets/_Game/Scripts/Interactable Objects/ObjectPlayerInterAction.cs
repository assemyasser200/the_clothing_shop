using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectPlayerInterAction : MonoBehaviour
{
    private bool checkForInteraction;
    private bool hasInteractedWith;
    private IInterActable interActable;
    [SerializeField] private TMP_Text rewardText;

    void Update()
    {
        if (!this.checkForInteraction)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            InterActWithPlayer();
        }
    }

    void InterActWithPlayer()
    {
        bool rewardCoins = Random.Range(0, 100) <= 75;
        this.checkForInteraction = false;
        this.hasInteractedWith = true;

        if(rewardCoins)
        {
            int rewardValue = interActable.CalculateRewardedCoins();
            rewardText.transform.parent.gameObject.SetActive(true);
            rewardText.text = "Found " + rewardValue.ToString() + " Coins!";
            AudioManager.instance.PlaySoundEffect("Earn");
        }
        else
        {
            rewardText.text = "Found Nothing!";
        }

        StartCoroutine("WaitBeforeNextInterAction");
    }

    IEnumerator WaitBeforeNextInterAction()
    {
        yield return new WaitForSeconds(5f);
        rewardText.transform.parent.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(this.hasInteractedWith)
        {
            return;
        }

        if(other.gameObject.CompareTag("Player"))
        {
            interActable = other.GetComponentInParent<IInterActable>();
            this.checkForInteraction = true;
        }    
    }

    void OnTriggerExit2D(Collider2D other)
    {
        interActable = null;
        this.checkForInteraction = false;
    }
}
