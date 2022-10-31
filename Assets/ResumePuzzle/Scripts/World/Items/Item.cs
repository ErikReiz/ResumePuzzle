using UnityEngine;

namespace ResumePuzzle.World.Item
{
	[System.Serializable]
	public enum ItemCategory
	{
		None,
		Key,
	}

	[System.Serializable]
	public struct ItemSpawnData
	{
		[SerializeField] public ItemCategory Category;
		[SerializeField] public GameObject ItemObject;
		[Tooltip("Code used to open chests, doors and etc. Each closed prop has a code")]
		[SerializeField] public int KeyCode;
	}
}