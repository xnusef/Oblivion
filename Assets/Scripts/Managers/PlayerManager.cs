using UnityEngine;
using Cinemachine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vcam;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnPosition;
    private GameObject player;
    private PlayerController playerController;

    void Start()
    {
        InputManager.IM.PM = this;
        spawnPlayer();
    }

    private void spawnPlayer()
    {
        //vcam = GameObject.Find("CineMachineCamera").GetComponent<CinemachineVirtualCamera>();

        player = GameObject.Instantiate(playerPrefab, spawnPosition.position, Quaternion.identity);
        player.transform.SetParent(this.transform);
        playerController = player.GetComponent<PlayerController>();

        vcam.m_Follow = player.transform;
    }

    public void ReceiveInput(string type, int value)
    {
        switch(type)
        {
            case "Move":
                playerController.pMovement.Direction = value;
                break;
            case "Jump":
                playerController.pJump.Jump();
                break;
            case "Drop":
                break;
            case "KnifeToEnemy":
                playerController.pAttack.KnifeToEnemy(value);
                break;
            case "KnifeToMouse":
                playerController.pAttack.KnifeToMouse();
                break;
            case "Pause":
                break;
            case "Enter":
                break;
            case "Previous":
                break;
            case "Next":
                break;
            case "AltF4":
                break;
            default:
                Debug.LogError(type + " " + value.ToString() + ": No es un tipo válido");
                break;
        }
    }
}