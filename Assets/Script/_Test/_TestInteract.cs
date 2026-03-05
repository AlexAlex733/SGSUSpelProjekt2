using UnityEngine;

public class _TestInteract : MonoBehaviour, IInteract
{
    public void OnInteract()
    {
        Debug.Log("Player Interacted");
    }
}
