using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlayerInterAction : MonoBehaviour
{
    private bool checkForInteraction;
    private bool hasInteractedWith;
    private IInterActable interActable;

    void Update()
    {
        if (!this.checkForInteraction)
        {
            return;
        }

        if (this.hasInteractedWith)
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
            DialogueManager.instance.TriggerDialogue("Reward");
            AudioManager.instance.PlaySoundEffect("Earn");
        }
        else
        {
            DialogueManager.instance.TriggerDialogue("NoReward");
        }
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
