using UnityEngine;
using ResumePuzzle.Interfaces;
using UnityEngine.InputSystem;
using UnityEngine.AddressableAssets;
namespace ResumePuzzle.Player
{
	public class PlayerAnimatorController : MonoBehaviour, IPlayerAnimatorController 
	{
		#region FIELDS
		private Animator animator;

		private int isMovingHash;
		private int directionXHash;
		private int directionYHash;
		#endregion

		private void Awake()
		{
			animator = GetComponent<Animator>();

			isMovingHash = Animator.StringToHash("IsMoving");
			directionXHash = Animator.StringToHash("DirectionX");
			directionYHash = Animator.StringToHash("DirectionY");
		}

		public void ReceiveMovementInput(ref InputAction.CallbackContext context)
		{
			Vector2 direction = context.ReadValue<Vector2>();

			animator.SetFloat(directionXHash, direction.x);
			animator.SetFloat(directionYHash, direction.y);

			animator.SetBool(isMovingHash, context.canceled ? false : true);
		}
	}
}

