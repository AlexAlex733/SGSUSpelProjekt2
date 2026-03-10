using UnityEngine;

public class KeypadInteraction : MonoBehaviour
{

    public string unlockCode = "1234";
    [SerializeField] string inputCode = "";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonInput (string input)
    {
        inputCode += input;
    }
}
