using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputManager : MonoBehaviour
{
    public delegate void PlayerStateHandler(playerStates newStates);
    public static event PlayerStateHandler onStateChange;
    
    void Update()
    {
        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        float verticalAxis = Input.GetAxisRaw("Vertical");

        if (horizontalAxis != 0f)
        {
            if (horizontalAxis < 0f)
            {
                if (onStateChange != null)
                    onStateChange(playerStates.Walk_Left);
            }
            else
            {
                if (onStateChange != null)
                    onStateChange(playerStates.Walk_Right);
            }
        }
        else if (verticalAxis != 0f)
        {
            if (verticalAxis < 0f)
            {
                if (onStateChange != null)
                    onStateChange(playerStates.Walk_Front);
            }
            else
            {
                if (onStateChange != null)
                    onStateChange(playerStates.Walk_Back);
            }
        }
        else if (horizontalAxis == 0f && verticalAxis == 0f)
        {
            if (onStateChange != null)
                onStateChange(playerStates.Idle);
        }
    }
}
