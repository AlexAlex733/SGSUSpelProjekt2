using UnityEngine;

public class CellDoor : MonoBehaviour, IInteract
{
    private GameObject cellDoor;
    private GameObject openDoor;
    Playerconditions playerconditions;



    private void Awake() //References - Alexander
    {
        cellDoor = this.gameObject;
        openDoor = GameObject.FindWithTag("OpenDoor");
        playerconditions = GameObject.FindWithTag("Player").GetComponent<Playerconditions>();
        if (playerconditions.starterKey) //If the player has a key then destroy the door collider.
        {
            Destroy(cellDoor);
            Invoke(nameof(OpenDoor), 0.1f);
        }
    }

    public void OpenDoor()
    {
        openDoor.SetActive(true);
    }

    public void OnInteract() //When the interact button is used then open the door- Alexander.
    {
        if (playerconditions.starterKey)
        {
            Interactionscript.Instance.MarkerInstantiate(false);
            cellDoor.SetActive(false);
            openDoor.SetActive(true);
        }
    }
}
