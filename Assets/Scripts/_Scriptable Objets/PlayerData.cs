using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player Data")]
public class PlayerData : ScriptableObject
{
    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private PlayerSpriteResolver[] playerSpriteResolvers;

    public GameObject PlayerGameObject
    {
        get{ return playerGameObject;}
        set{playerGameObject = value;}
    } 

    public PlayerSpriteResolver[] SpriteResolvers
    {
        get{ return playerSpriteResolvers;}
    } 

    public Vector3 ObjectPosition
    {
        get{ return playerGameObject.transform.position;}
    }  

    public float ScaleX
    {
        get{ return playerGameObject.transform.localScale.x;}
    }    
}
