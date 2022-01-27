using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStandController : MonoBehaviour
{
    [SerializeField] private GameObject flame;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer).Equals("Player"))
        {
            if (!flame.activeSelf)
            {
                flame.SetActive(true);
                AudioManager.instance.PlaySoundEffect("Torch");
            }
        }
    }
}
