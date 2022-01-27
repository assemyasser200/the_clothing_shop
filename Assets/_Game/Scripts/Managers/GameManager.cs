using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnPlayerPosition;
    [SerializeField] private CameraFollowController cameraFollowController;
    [SerializeField] private PlayerInventoryManager inventoryManager;
    [SerializeField] private UIShopManager shopManager;
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

        cameraFollowController.SetPlayerToFollow(player.transform);
        shopManager.ResetItemsOwnerShip();
        inventoryManager.SetPlayer(player.GetComponent<PlayerOutfitSwapController>());
    }

    void Start()
    {
        DialogueManager.Instance.TriggerDialogue("WTD");
    }
}
