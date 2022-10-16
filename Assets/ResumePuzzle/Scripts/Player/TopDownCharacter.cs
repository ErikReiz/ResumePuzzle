using UnityEngine;
using UnityEngine.InputSystem;
using ResumePuzzle.Interfaces;

namespace ResumePuzzle.Player
{
	public class TopDownCharacter : MonoBehaviour, IPlayer
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
		#endregion

		private void Awake()
		{
			animatorController = GetComponent<IPlayerAnimatorController>();
			playerRigidbody = GetComponent<Rigidbody2D>();

			interactionSystem = new(interactionLayer, interactionRadius);
		}

		private void Update()
		{
			playerRigidbody.velocity = direction * movementSpeed * Time.deltaTime;	
		}

		public void OnMove(InputAction.CallbackContext context)
		{
			direction = context.ReadValue<Vector2>();
			animatorController.ReceiveMovementInput(ref context);
		}

		public void OnInteract()
		{
			
			interactionSystem.Interact(transform.position);
		}
	}
}

