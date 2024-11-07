using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3.5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;
    private AudioSource audioSource;

    public LayerMask interacablesLayer;
    public float interactionRange = 1.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        rb.velocity = moveInput * moveSpeed;

        if (moveInput != Vector2.zero && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else if (moveInput == Vector2.zero && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Interact();
        }
    }

    private void Interact()
    {
        Vector2 interactPosition = rb.position + moveInput.normalized * interactionRange;
        Collider2D collider = Physics2D.OverlapCircle(interactPosition, 0.1f, interacablesLayer);
        if (collider != null)
        {
            var interactable = collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        animator.SetBool("isMoving", true);
        if (!context.canceled && moveInput.x != 0)
        {
            animator.SetFloat("lastInputX", moveInput.x);
        }
        animator.SetBool("isMoving", !context.canceled);
        animator.SetFloat("inputX", moveInput.x);
    }
}