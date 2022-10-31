using UnityEngine.InputSystem;

namespace ResumePuzzle.Interfaces
{
	public interface IPlayerAnimatorController
	{
		#region METHODS
		public void ReceiveMovementInput(ref InputAction.CallbackContext context);
		#endregion
	}
}
