using UnityEngine;
using UnityEngine.InputSystem;

// Made By Rami
public class _PlayerInteract : MonoBehaviour
{
    [Header("Player Interact Settings")]
    [SerializeField] private float interactDistance;

    
    public void OnInteract(InputAction.CallbackContext context) // if the E key is pressed then 
    {
        //Debug.Log("Pressed E");

        if (context.performed)
        {
            TryInteract();
        }
    }

    public void TryInteract() // here we try to interact even though no try we cast a sphere and try to get IInteract interface and call OnInteract();
    {
        RaycastHit[] interactCheck = Physics.SphereCastAll(this.transform.position, interactDistance, Vector3.up, 0f);

        foreach (RaycastHit hit in interactCheck)
        {
            IInteract interact = hit.collider.gameObject.GetComponent<IInteract>();

            interact?.OnInteract();
        }
    }
}
