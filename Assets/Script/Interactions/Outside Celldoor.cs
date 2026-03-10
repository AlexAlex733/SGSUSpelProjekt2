using UnityEngine;

public class OutsideCelldoor : MonoBehaviour, IInteract
{
    [SerializeField] GameObject doorImage;
    [SerializeField] GameObject behindDoor;
    [SerializeField] static bool isTriggered = false;
    private PlayerMovement playerMovement;

    private void Awake() //HIdes the images before the player sees them - Alexander.
    {
        doorImage.SetActive(false);
        behindDoor.SetActive(false);
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }
    public void OnInteract() //Allows the player to look at the images and stop movements while interacting - Alexander.
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
