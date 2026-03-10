using UnityEngine;

public class CellDoor : MonoBehaviour, IInteract
{
    private GameObject door;
    Playerconditions playerconditions;



    private void Awake() //References - Alexander
    {
        door = this.gameObject;
        playerconditions = GameObject.FindWithTag("Player").GetComponent<Playerconditions>();
        if (playerconditions.starterKey) //If the player has a key then destroy the door collider.
        {
            door.GetComponent<SpriteRenderer>().enabled = true;
            door.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void OnInteract() //When the interact button is used then open the door- Alexander.
    {
        if (playerconditions.starterKey)
        {
            Interactionscript.Instance.MarkerInstantiate(false);
            door.GetComponent<SpriteRenderer>().enabled = true;
            door.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
