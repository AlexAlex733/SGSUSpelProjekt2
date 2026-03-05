using UnityEngine;

public class OutsideCelldoor : MonoBehaviour, IInteract
{
    [SerializeField] GameObject doorImage;
    [SerializeField] GameObject behindDoor;
    [SerializeField] bool isTriggered = false;

    private void Awake()
    {
        doorImage.SetActive(false);
        behindDoor.SetActive(false);
    }
    public void OnInteract()
    {
        Debug.Log("Is this even working? " + isTriggered);
        if (!isTriggered)
        {
            doorImage.SetActive(true);
            behindDoor.SetActive(true);
            isTriggered = true;
        }
        if (isTriggered)
        {
            doorImage.SetActive(false);
            behindDoor.SetActive(false);
            isTriggered = false;
        }
    }
}
