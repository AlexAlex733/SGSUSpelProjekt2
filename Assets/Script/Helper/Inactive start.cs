using UnityEngine;

public class Inactivestart : MonoBehaviour
{
    GameObject door;
    private void Awake()
    {
        Invoke(nameof(Inactiveactive), 0.05f);
    }
    private void Inactiveactive() // Activates and inactivates a gameobject - Alexander
    {
        try
        {
            door = GameObject.FindWithTag("Door");
        }
        catch 
        {
            ;
        }
        if (door != null)
        {
            door.GetComponent<SpriteRenderer>().enabled = false;
            door.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
