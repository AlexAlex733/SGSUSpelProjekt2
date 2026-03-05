using UnityEngine;

public class CellDoor : MonoBehaviour, IInteract
{
    private GameObject cellDoor;
    private GameObject openDoor;
    Playerconditions playerconditions;



    private void Awake()
    {
        cellDoor = this.gameObject;
        openDoor = GameObject.FindWithTag("OpenDoor");
        playerconditions = GameObject.FindWithTag("Player").GetComponent<Playerconditions>();
        if (playerconditions.starterKey)
        {
            Destroy(cellDoor);
            Invoke(nameof(OpenDoor), 0.1f);
        }
    }

    public void OpenDoor()
    {
        openDoor.SetActive(true);
    }

    public void OnInteract()
    {
        if (playerconditions.starterKey)
        {
            Interactionscript.Instance.MarkerInstantiate(false);
            cellDoor.SetActive(false);
            openDoor.SetActive(true);
        }
    }
}
