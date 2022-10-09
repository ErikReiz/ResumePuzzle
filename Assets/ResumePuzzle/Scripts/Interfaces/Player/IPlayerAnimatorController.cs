using UnityEngine.InputSystem;

namespace ResumePuzzle.Interfaces
{
	public interface IPlayerAnimatorController
	{
		public void ReceiveMovementInput(ref InputAction.CallbackContext context);
	}
}
