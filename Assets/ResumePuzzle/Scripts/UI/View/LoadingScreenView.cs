using TMPro;
using Zenject;
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
		[SerializeField] private TMP_Text loadingText;

		[Header("DOTWeen")]
		[SerializeField] private float tweeningLength = 0.3f;
		#endregion

		#region FIELDS
		[Inject] private Canvas canvas;
		#endregion

		private void Start()
		{
			transform.localScale = Vector3.zero;
		}

		public Task Show()
		{
			canvas.gameObject.SetActive(true);
			return transform.DOScale(new Vector3(1, 1), tweeningLength).AsyncWaitForCompletion();
		}

		public Task Hide()
		{
			canvas.gameObject.SetActive(false);
			return transform.DOScale(Vector3.zero, tweeningLength).AsyncWaitForCompletion();
		}

		public void UpdateLoadingBar(float loadingPercent)
		{
			//loadingText.text = (loadingPercent * 100f).ToString();
			loadingSlider.value = loadingPercent;
		}
	}
}