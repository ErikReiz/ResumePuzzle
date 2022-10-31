using UnityEngine;
using UnityEngine.InputSystem;
using ResumePuzzle.World.Item;
using ResumePuzzle.Interfaces;
using System.Collections.Generic;

namespace ResumePuzzle.Player
{
	public class TopDownCharacter : MonoBehaviour, IPlayer, IInventory
	{
		#region SERIALIZABLE FIELDS
		[SerializeField] private float movementSpeed = 5f;

		[Header("Interaction")]
		[SerializeField] private LayerMask interactionLayer;
		[SerializeField] private float interactionRadius;
		#endregion

		#region FIELDS
		private IPlayerAnimatorController animatorController;
		private Rigidbody2D playerRigidbody;
		private Vector2 direction;

		private InteractionSystem interactionSystem;
		private List<int> keyCodes = new();
		#endregion

		private void Awake()
		{
			animatorController = GetComponent<IPlayerAnimatorController>();
			playerRigidbody = GetComponent<Rigidbody2D>();

			interactionSystem = new(this, interactionLayer, interactionRadius);
		}

		private void Update()
		{
			playerRigidbody.velocity = direction * movementSpeed;	
		}

		public void OnMove(InputAction.CallbackContext context)
		{
			direction = context.ReadValue<Vector2>();
			animatorController.ReceiveMovementInput(ref context);
		}

		public void OnInteractInput()
		{
			interactionSystem.Interact(transform.position);
		}

		#region INVENTORY
		public void Take(KeyItem key)
		{
			keyCodes.Add(key.KeyCode);
		}

		public bool ContainsKey(int keyCode)
		{
			return keyCodes.Contains(keyCode);
		}
		#endregion
	}
}

