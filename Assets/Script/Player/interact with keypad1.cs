using UnityEngine;

public class interactwithkeypad1 : MonoBehaviour
{
    [SerializeField] GameObject Keypad;
    public bool TurnOffKeypad = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TurnOffKeypad = false;
        Keypad.SetActive(TurnOffKeypad);
    }

    // Update is called once per frame
    void Update()
    {
        Keypad.SetActive(TurnOffKeypad);
        if (Input.GetKeyDown(KeyCode.F))
        {
            TurnOffKeypad = true;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            TurnOffKeypad = false;
        }
    }
}
