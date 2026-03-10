using UnityEngine;
using UnityEngine.SceneManagement;

public class NextRoomScript : MonoBehaviour
{
    Animator animator; //Made by Alexander
    [SerializeField] int roomNumber;
    [SerializeField] Vector3 nextPlayerPosition;
    [SerializeField] GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) //If the player collides then load the next scene.
        {
            Debug.Log(other);
            if (player == null)
            {
                player = other.gameObject;
            }
            TeleportToNextRoom();
        }  
    }
    private void TeleportToNextRoom() //Teleports the player before going to the next room.
    {
        //Transition.Instance.StartTransition();
        SceneManager.LoadScene(roomNumber);
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = nextPlayerPosition;
        player.GetComponent<CharacterController>().enabled = true;
        
    }
}
