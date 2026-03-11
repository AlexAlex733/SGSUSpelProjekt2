using TMPro;
using UnityEngine;

public class KeypadInteraction : MonoBehaviour
{
    public TMP_Text keyPadText;
    GameObject door;
    public string unlockCode = "1937";
    [SerializeField] string inputCode = "";

    public void Awake()
    {
        door = GameObject.FindWithTag("Door");
        keyPadText = GameObject.FindWithTag("KeypadUI").GetComponent<TMP_Text>();
    }

    public void ButtonInput (string input)
    {
        inputCode += input;
        if (inputCode.Length > 4)
        {
            inputCode = "";
        }
        keyPadText.text = $"{inputCode}";
        if (unlockCode == inputCode)
        {
            door.GetComponent<SpriteRenderer>().enabled = true;
            door.GetComponent <BoxCollider>().enabled = false;
            Keypad.isDoorCellOutsideOpen = true;
            Debug.Log("The Door is open");
        }
        else
        {
            door.GetComponent<SpriteRenderer>().enabled = false;
            door.GetComponent<BoxCollider>().enabled = true;
            Keypad.isDoorCellOutsideOpen = false;
            Debug.Log("The Door is closed");
        }
    }
}
