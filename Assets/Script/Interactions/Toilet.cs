using UnityEngine;

public class Toilet : MonoBehaviour, IInteract
{
    [SerializeField] private GameObject closedDoor;
    [SerializeField] private GameObject openDoor;
    private void Start()
    {
        openDoor = GameObject.FindWithTag("OpenDoor");
        closedDoor = GameObject.FindWithTag("ClosedDoor");
    }

    public void OnInteract()
    {
        Interactionscript.Instance.MarkerInstantiate(false);
        Debug.Log("Player has picked up the key");
        closedDoor.SetActive(false);
        openDoor.SetActive(true);
        Destroy(this.gameObject);
    }
}
