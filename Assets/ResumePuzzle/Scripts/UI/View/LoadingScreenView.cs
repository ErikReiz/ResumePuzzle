using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using ResumePuzzle.Interfaces;
using System.Threading.Tasks;

namespace ResumePuzzle.UI.View
{
	public class LoadingScreenView : MonoBehaviour, ILoadingScreenView
	{
		#region SERIALIZABLE FIELDS
		[SerializeField] private Slider loadingSlider;

		[Header("DOTWeen")]
		[SerializeField] private float tweeningLength = 0.3f;
		#endregion

		#region FIELDS
		#endregion

		public Task Show()
		{
			return transform.DOScale(new Vector3(1, 1), tweeningLength).AsyncWaitForCompletion();
		}

		public Task Hide()
		{
			return transform.DOScale(Vector3.zero, tweeningLength).AsyncWaitForCompletion();
		}

		public void UpdateLoadingBar(float loadingPercent)
		{
			loadingSlider.value = loadingPercent;
		}
	}
}