using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject player;
    private void Update() // Moves the camera to the players position - Alexander
    {
        cam.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -2);
    }
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
}
