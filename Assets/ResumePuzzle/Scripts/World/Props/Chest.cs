using ResumePuzzle.Interfaces;
using ResumePuzzle.World.Item;
using System.Collections.Generic;
using UnityEngine;

namespace ResumePuzzle.World.Prop
{
	public class Chest : MonoBehaviour, IInteractable
	{
		#region SERIALIZABLE FIELDS
		[SerializeField] private List<ItemSpawnData> dropedItem;
		[SerializeField] private Transform itemSpawnPosition;

		[Header("Lock")]
		[SerializeField] private bool isLocked = false;
		[SerializeField] private int keyCode;

		[Header("Visual")]
		[SerializeField] private Sprite afterOpened;
		#endregion

		#region FIELDS
		private SpriteRenderer spriteRenderer;
		#endregion

		private void Awake()
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
		}

		public void OnInteracted(IInventory inventory)
		{
			if (isLocked)
			{
				if (!inventory.ContainsKey(keyCode))
					return;
			}

			SpawnItem();
			ChangeItemState();
			AfterInteraction();
		}

		private void SpawnItem()
		{
			foreach (var item in dropedItem)
			{
				GameObject spawnedObject = Instantiate(item.ItemObject, itemSpawnPosition.position, transform.rotation);

				SpriteRenderer objectRenderer = spawnedObject.GetComponent<SpriteRenderer>();
				objectRenderer.sortingLayerName = spriteRenderer.sortingLayerName;
				objectRenderer.sortingOrder = spriteRenderer.sortingOrder;

				if (item.Category == ItemCategory.Key)
					InitializeKey(spawnedObject, item);
			}
		}

		private void ChangeItemState()
		{
			if (afterOpened)
				spriteRenderer.sprite = afterOpened;
		}

		private void InitializeKey(GameObject spawnedObject, ItemSpawnData itemSpawnData)
		{
			KeyItem key = spawnedObject.GetComponent<KeyItem>();
			key.Initalize(itemSpawnData.KeyCode);
		}

		private void AfterInteraction()
		{
			gameObject.layer = 0;
			Destroy(this);
		}
	}
}

