using UnityEngine;

public class Inactivestart : MonoBehaviour
{
    private void Start()
    {
        Invoke(nameof(Inactiveactive), 0.05f);
    }
    private void Inactiveactive()
    {
        this.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
