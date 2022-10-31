using ResumePuzzle.Interfaces;
using UnityEngine;
using Zenject;

namespace ResumePuzzle.World.Prop
{
	public class Door : MonoBehaviour, IInteractable
	{
		#region SERIALIZABLE FIELDS
		[Header("Lock")]
		[SerializeField] private bool isLocked = false;
		[SerializeField] private int keyCode;
		#endregion

		#region FIELDS
		[Inject] private IGameManager gameManager;
		#endregion

		public void OnInteracted(IInventory inventory)
		{
			if (isLocked)
			{
				if (!inventory.ContainsKey(keyCode))
					return;
			}

			gameManager.EndGame();
		}
	}
}

