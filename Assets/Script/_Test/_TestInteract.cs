using UnityEngine;

// Made by Rami
public class _TestInteract : MonoBehaviour, IInteract
{
    public void OnInteract() // this is for testing and to show how other interactables look like
    {
        Debug.Log("Player Interacted");
    }
}
