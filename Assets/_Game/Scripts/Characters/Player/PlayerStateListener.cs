using UnityEngine;

public class PlayerStateListener : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMovementController movementController;
    
    private string currentPlayerDirection;
    private playerStates currentState = playerStates.Idle;
    private playerStates previousState = playerStates.Idle;

    void OnEnable()
    {
        GameInputManager.onStateChange += onStateChange;
    }

    void OnDisable()
    {
        GameInputManager.onStateChange -= onStateChange;
    }
    
    void FixedUpdate()
    {
        // if(!GameManager.isGameStarted || GameManager.isGamePaused || GameManager.isGameOver)
        // {
        //     return;
        // }

        onStateCycle();
    }

    void onStateCycle()
    {
        switch (currentState)
        {   
            case playerStates.Idle:
                break;
    
            case playerStates.Walk_Back:
                movementController.VerticalMovement(1);
                break;

            case playerStates.Walk_Front:
                movementController.VerticalMovement(-1);
                break;

            case playerStates.Walk_Left:
                movementController.HorizontalMovement(-1);
                break;
            
            case playerStates.Walk_Right:
                movementController.HorizontalMovement(1);
                break;
        }
    }

    public void onStateChange(playerStates newState)
    {
        //Debug.Log("1-newState "+newState);
        if(newState == currentState)
            return;

        switch (newState)
        {
            case playerStates.Idle:
          
                movementController.StopMovement();
                
                if(previousState == playerStates.Idle &&
                    currentState == playerStates.Idle)
                {
                    animator.Play("IdleFront");
                }
                
                if(currentState == playerStates.Walk_Front)
                {
                    animator.Play("IdleFront");
                }
                else if(currentState == playerStates.Walk_Back)
                {
                    animator.Play("IdleBack");
                }
                else if(currentState == playerStates.Walk_Left)
                {
                    animator.Play("IdleLeftSide");
                }
                else if(currentState == playerStates.Walk_Right)
                {
                    animator.Play("IdleRightSide");
                }
                break;

            case playerStates.Walk_Left:
                animator.Play("WalkLeft");
                break;

            case playerStates.Walk_Right:
                animator.Play("WalkRight");
                break;

            case playerStates.Walk_Front:
                animator.Play("WalkFront");
                break;

            case playerStates.Walk_Back:
                animator.Play("WalkBack");
                break;
        }

        previousState = currentState;
        currentState = newState;
    }

    bool checkForValidStateTransition(playerStates newState)
    {
        bool moveToState = false;

        switch (currentState)
        {
            case playerStates.Idle:
                break;
        }
        return moveToState;
    }

//     // check if there is any reason this state should not be allowed to begin.
//     bool checkIfAbortOnStateCondition(playerStates newState)
//     {
//         // Value of true means 'Abort'. Value of false means 'Continue'.
//         bool abortState = false;

//         switch (newState)
//         {
//             case playerStates.Idle:
//                 if (jumpCount.IntVar != 0)
//                 {
//                     abortState = true;
//                 }
//                 break;

//             case playerStates.Left:
//                 break;

//             case playerStates.Right:
//                 break;

//              case playerStates.StompAttack:
//                 if(!isAirBorn)
//                 {
//                     abortState = true;
//                 }
                
//                 break;

//             case playerStates.Jumping:
//                 if(jumpCount.IntVar == 2)
//                 {
//                     abortState = true;
//                 }
//                 //float nextAllowedJumpTime =
//                 //    stateDelayTimer[(int)playerStates.Jumping];

//                 //if (nextAllowedJumpTime == 0f || nextAllowedJumpTime > Time.time)
//                 //    abortState = true;
//                 break;

//             case playerStates.Landing:
//                 break;

//             case playerStates.Falling:
//                 if(jumpCount.IntVar > 0)
//                 {
//                     abortState = true;
//                 }
//                 break;

//             case playerStates.DropDownFromPlatform:
//                 if(!canDropDownFormPlatform)
//                 {
//                     abortState = true;
//                 }
//                 break;

//             case playerStates.Dash:
//                 float nextAllowedDash =
//                     stateDelayTimer[(int)playerStates.Dash];

//                 if (nextAllowedDash > Time.time)
//                 {
//                     abortState = true;
//                 }
//                 break;

//              case playerStates.MeleeAttack:
//                 float nextAllowedMeleeAttack =
//                     stateDelayTimer[(int)playerStates.MeleeAttack];

//                 if (nextAllowedMeleeAttack > Time.time || currentEnemyTarget.GameObjectTarget == null)
//                 {
//                     abortState = true;
//                 }
//                 break;

//             case playerStates.PushedBack:
//                 break;

//             case playerStates.Dead:
//                 break;
//         }

//         return abortState;
//     }
}
