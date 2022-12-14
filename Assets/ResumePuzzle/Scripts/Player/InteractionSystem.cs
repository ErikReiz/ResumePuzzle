using ResumePuzzle.Interfaces;
using UnityEngine;

namespace ResumePuzzle.Player
{
	public class InteractionSystem
	{
		#region FIELDS
		private IInventory inventory;
		private int interactionLayer;
		private float interactionRadius;
		#endregion

		public InteractionSystem(IInventory inventory, int interactionLayer, float interactionRadius)
		{
			this.inventory = inventory;
			this.interactionLayer = interactionLayer;
			this.interactionRadius = interactionRadius;
		}

		public void Interact(Vector2 origin)
		{
			Collider2D hitCollider = Physics2D.OverlapCircle(origin, interactionRadius, interactionLayer);
			if (!hitCollider)
				return;

			GameObject hitObject = hitCollider.gameObject;
			Debug.Log(hitObject);
			IInteractable component = hitObject.GetComponent<IInteractable>();
			if (component != null)
				component.OnInteracted(inventory);
		}
	}
}