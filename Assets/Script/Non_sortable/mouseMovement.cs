using UnityEngine;
using UnityEngine.InputSystem;

public class mouseMovement : MonoBehaviour
{
    public GameObject hand;
    public Vector3 mousePos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        hand.transform.position = mousePos.normalized;
    }
}
