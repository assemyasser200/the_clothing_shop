using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    [SerializeField] private Transform CamTransform;
    public Transform target;
    public float followspeed;
    
    public void SetPlayerToFollow(Transform player)
    {
        target = player;
    }

    void LateUpdate () 
    {
        if(target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, this.transform.position.z);
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, Time.deltaTime * followspeed);
        }
    }
}
