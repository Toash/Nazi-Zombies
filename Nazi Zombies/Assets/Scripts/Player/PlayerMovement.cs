using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{

	private CharacterController characterController;
	private PlayerCamera playerCamera;
	private Player player;

	private Vector3 moveVector;

	private float verticalInput;
	private float horizontalInput;



	void Awake()
	{
		characterController = this.GetComponent<CharacterController>();
		playerCamera = this.GetComponent<PlayerCamera>();
		player = this.GetComponent<Player>();
	}

	void Update()
	{
		readInput();
		calculateMoveVector();
		movePlayer();
	}

	private void calculateMoveVector()
	{
		Vector3 relativeVertical = this.transform.forward;
		Vector3 relativeHorizontal = this.transform.right;
		Vector3 vertical = relativeVertical * verticalInput;
		Vector3 horizontal = relativeHorizontal * horizontalInput;

		moveVector = (vertical + horizontal) * player.getMoveSpeed()+Physics.gravity;

		
	}
	private void movePlayer()
	{
		characterController.Move(moveVector*Time.deltaTime);
	}

	private void readInput()
	{
		verticalInput = Input.GetAxisRaw("Vertical");
		horizontalInput = Input.GetAxisRaw("Horizontal");
	}

}