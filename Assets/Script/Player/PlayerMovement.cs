using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float currentSpeed;
    [SerializeField] private Vector2 moveInput;
    private Vector2 moveDir;
    [SerializeField] private bool isFacingUp;

    [Header("Player Components")]
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterController controller;

    [Header("Game Objects")]
    [SerializeField] private GameObject player;

    void Start()
    {
        try
        {
            animator = GetComponent<Animator>(); // Get the Animator component attached to the player
            controller = GetComponent<CharacterController>(); // Get the CharacterController component attached to the player
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Component: {animator || controller} not found on the player: {ex.Message}");
        }
    }

    public void OnMove(InputAction.CallbackContext context)  // This method handles the player movement input //Fixed your speeling error
    {
        moveInput = context.ReadValue<Vector2>(); // Read the movement input from the player
        moveDir = new Vector2(moveInput.x, moveInput.y).normalized; // Normalize the movement direction to ensure consistent movement speed in all directions
    }

    public void Move()
    {
            controller.Move(moveSpeed * Time.deltaTime * moveDir); // Move the player using the CharacterController
            currentSpeed = controller.velocity.magnitude; // Update the current speed based on the CharacterController's velocity
            AnimationVariableSetter();
    }
    public void AnimationVariableSetter()
    {
        if(controller.velocity.y > 0) // Checks whether the player is going up or down.
            isFacingUp = true;
        if(controller.velocity.y < 0)
            isFacingUp = false;
        animator.SetFloat("Speed", currentSpeed); // Shows the animator how fast the player is
        animator.SetBool("isFacingUp", isFacingUp); // Shows the animator whether the player is going up or down
    }
    public void FlipCharacter()
    {
        if (controller.velocity.x > 0)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            if (controller.velocity.x > 0 && isFacingUp)
                isFacingUp = false ;
        }
        if (controller.velocity.x < 0)
        {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
            if (controller.velocity.x < 0 && isFacingUp)
                isFacingUp = false;
        }

    }

    private void FixedUpdate()
    {
           Move(); // Call the Move method every frame to update the player's position
           FlipCharacter(); // Call the Flip function
    }
}
