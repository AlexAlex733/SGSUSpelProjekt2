using UnityEngine;

public class Playerconditions : MonoBehaviour
{
    private GameObject player;
    public bool starterKey = false;
    private void Start() // Conditions for different events in the game - Alexander
    {
        player = this.gameObject;
    }
}
