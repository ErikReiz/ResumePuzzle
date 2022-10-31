using ResumePuzzle.Interfaces;
using UnityEngine;

namespace ResumePuzzle.World.Item
{
	public class KeyItem : MonoBehaviour, IInteractable
	{
		#region SERIALIZABLE FIELDS
		[SerializeField] private int keyCode;
		#endregion

		#region PROPERTIES
		public int KeyCode { get { return keyCode; } }
		#endregion

		public void Initalize(int code)
		{
			keyCode = code;
		}

		public void OnInteracted(IInventory inventory)
		{
			inventory.Take(this);
			Destroy(gameObject);
		}
	}
}