using UnityEngine;

public class OutsideCelldoor : MonoBehaviour, IInteract
{
    [SerializeField] GameObject doorImage;
    [SerializeField] GameObject behindDoor;
    [SerializeField] static bool isTriggered = false;
    private PlayerMovement playerMovement;

    private void Awake()
    {
        doorImage.SetActive(false);
        behindDoor.SetActive(false);
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }
    public void OnInteract()
    {
        Debug.Log("Is this even working? " + isTriggered);

        isTriggered = !isTriggered;

        if (isTriggered)
        {
            doorImage.SetActive(true);
            behindDoor.SetActive(true);
            playerMovement.enabled = false;
        }
        if (!isTriggered)
        {
            doorImage.SetActive(false);
            behindDoor.SetActive(false);
            playerMovement.enabled = true;
        }
    }
}
