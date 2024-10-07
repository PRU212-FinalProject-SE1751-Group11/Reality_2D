using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField]
	private float moveSpeed = 3.5f;

	private Rigidbody2D rb;

	private Vector2 moveInput;

	private Animator animator;
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}
	void FixedUpdate()
	{
		rb.velocity = moveInput * moveSpeed;
	}
	public void move(InputAction.CallbackContext context)
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
