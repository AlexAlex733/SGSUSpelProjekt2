using UnityEngine;

public class Inactivestart : MonoBehaviour
{
    private void Awake()
    {
        Invoke(nameof(Inactiveactive), 0.05f);
    }
    private void Inactiveactive() // Activates and inactivates a gameobject - Alexander
    {
        this.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
