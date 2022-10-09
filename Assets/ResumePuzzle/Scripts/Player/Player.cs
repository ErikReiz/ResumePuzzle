using UnityEngine;
using UnityEngine.InputSystem;
using ResumePuzzle.Interfaces;

namespace ResumePuzzle.Player
{
	public class Player : MonoBehaviour
	{
		#region SERIALIZABLE FIELDS
		[SerializeField] private float movementSpeed = 5f;
		#endregion

		#region FIELDS
		private IPlayerAnimatorController animatorController;
		private Rigidbody2D rigidbody;

		private Vector2 direction;
		#endregion

		private void Awake()
		{
			animatorController = GetComponent<IPlayerAnimatorController>();
			rigidbody = GetComponent<Rigidbody2D>();
		}

		private void Update()
		{
			rigidbody.velocity = direction * movementSpeed;			
		}

		public void OnMove(InputAction.CallbackContext context)
		{
			direction = context.ReadValue<Vector2>();
			animatorController.ReceiveMovementInput(ref context);
		}
	}
}

