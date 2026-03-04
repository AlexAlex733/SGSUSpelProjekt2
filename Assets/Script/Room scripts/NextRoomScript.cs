using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextRoomScript : MonoBehaviour
{
    Animator animator;
    [SerializeField] int roomNumber;
    [SerializeField] Vector3 nextPlayerPosition;
    [SerializeField] GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(other);
            if (player == null)
            {
                player = other.gameObject;
            }
            TeleportToNextRoom();
        }  
    }
    private void TeleportToNextRoom()
    {
        Transition.Instance.StartTransition();
        SceneManager.LoadScene(roomNumber);
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = nextPlayerPosition;
        player.GetComponent<CharacterController>().enabled = true;
        
    }
}
