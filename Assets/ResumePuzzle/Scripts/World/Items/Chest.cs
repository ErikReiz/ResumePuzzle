using UnityEngine;
using ResumePuzzle.Interfaces;

namespace ResumePuzzle.World.Interactable
{
	public class Chest : MonoBehaviour, IInteractable
	{
		#region SERIALIZABLE FIELDS
		[SerializeField] private Sprite openedChest;
		[SerializeField] private GameObject dropItem;
		#endregion

		#region FIELDS
		private SpriteRenderer spriteRenderer;
		#endregion

		private void Awake()
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
		}

		public void OnInteracted()
		{
			spriteRenderer.sprite = openedChest;

			SpawnItem();
		}

		private void SpawnItem()
		{
			var temp = Instantiate(dropItem, transform.position, transform.rotation).GetComponent<SpriteRenderer>();

			temp.sortingLayerName = spriteRenderer.sortingLayerName;
			temp.sortingOrder = spriteRenderer.sortingOrder;
		}
	}
}

