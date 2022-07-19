using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnPosition;
    private GameObject player;
    private PlayerController playerController;

    private void Start()
    {
        InputManager.IM.PM = this;
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        player = GameObject.Instantiate(playerPrefab, spawnPosition.position, Quaternion.identity);
        player.transform.SetParent(this.transform);
        playerController = player.GetComponent<PlayerController>();
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
            case "Attack":
                break;
            case "Parry":
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
                Debug.Log(type + " " + value.ToString());
                break;
        }
    }
}