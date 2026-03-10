using UnityEngine;

public class Toilet : MonoBehaviour, IInteract
{
    [SerializeField] private GameObject closedDoor;
    [SerializeField] private GameObject openDoor;
    private Playerconditions playerconditions;
    private void Awake()
    {
        openDoor = GameObject.FindWithTag("OpenDoor");
        closedDoor = GameObject.FindWithTag("ClosedDoor");
        playerconditions = GameObject.FindWithTag("Player").GetComponent<Playerconditions>();
        if (playerconditions.starterKey) 
        {
            Destroy(this.gameObject);
        }
    }

    public void OnInteract() //ALlows the player to pick up a key - Alexander
    {
        Interactionscript.Instance.MarkerInstantiate(false);
        playerconditions.starterKey = true;
        Debug.Log("Player has picked up the key");
        Destroy(this.gameObject);
    }
}
