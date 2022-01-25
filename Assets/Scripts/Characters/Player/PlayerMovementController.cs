using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private GameObject frontSide;
    [SerializeField] private GameObject backSide;
    [SerializeField] private GameObject leftSide;
    [SerializeField] private GameObject rightSide;

    public void HorizontalMovement(int direction)
    {
        frontSide.SetActive(false);
        backSide.SetActive(false);

        if(direction > 0)
        {
            rightSide.SetActive(true);
            leftSide.SetActive(false);
        }
        else if(direction < 0)
        {
            rightSide.SetActive(false);
            leftSide.SetActive(true);
        }
        rigidBody.velocity = new Vector2(walkSpeed * direction, 0f);
    }

    public void VerticalMovement(int direction)
    {
        rightSide.SetActive(false);
        leftSide.SetActive(false);

        if(direction > 0)
        {
            frontSide.SetActive(false);
            backSide.SetActive(true);
        }
        else if(direction < 0)
        {
            frontSide.SetActive(true);
            backSide.SetActive(false);
        }

        rigidBody.velocity = new Vector2(0f, walkSpeed * direction);
    }

}
