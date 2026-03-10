using UnityEngine;

public class Keypad: MonoBehaviour, IInteract
{
    [SerializeField] private GameObject keypad;
    [SerializeField] private bool isTriggered;
    [SerializeField] private PlayerMovement playerMovement;

    private void Awake()
    {
        keypad = GameObject.FindWithTag("Keypad");
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        keypad.SetActive(false);
    }
    public void OnInteract() //Allows the player to open up the keypad - ALexander
    {
        Debug.Log("Is this even working? " + isTriggered);

        isTriggered = !isTriggered;

        if (isTriggered)
        {
            keypad.SetActive(true);
            playerMovement.enabled = false;
        }
        if (!isTriggered)
        {
            keypad.SetActive(false);
            playerMovement.enabled = true;
        }
    }
}
