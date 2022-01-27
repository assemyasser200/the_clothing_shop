using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnPlayerPosition;
    [SerializeField] private CameraFollowController cameraFollowControllerr;
    private GameObject player;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelLoad;   
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelLoad;   
    }

    void OnLevelLoad(Scene scene, LoadSceneMode mode)
    {
        player = Instantiate(playerPrefab, spawnPlayerPosition.position, Quaternion.identity);
        player.GetComponent<PlayerOutfitSwapController>().SetPlayerDefaultOutfit();
        player.GetComponent<PlayerCoins>().InitializePlayerCoins();

        cameraFollowControllerr.SetPlayerToFollow(player.transform);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
