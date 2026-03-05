using UnityEngine;
using UnityEngine.InputSystem;

public class _PlayerInteract : MonoBehaviour
{
    [Header("Player Interact Settings")]
    [SerializeField] private float interactDistance;

    
    public void OnInteract(InputAction.CallbackContext context)
    {
        //Debug.Log("Pressed E");

        if (context.performed)
        {
            TryInteract();
        }
    }

    public void TryInteract()
    {
        RaycastHit[] interactCheck = Physics.SphereCastAll(this.transform.position, interactDistance, Vector3.up, 0f);

        foreach (RaycastHit hit in interactCheck)
        {
            IInteract interact = hit.collider.gameObject.GetComponent<IInteract>();

            interact?.OnInteract();
        }
    }
}
