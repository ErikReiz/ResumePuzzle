using DG.Tweening;
using ResumePuzzle.Interfaces;
using System.Collections;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ResumePuzzle.UI.View
{
	public class LoadingScreenView : MonoBehaviour, ILoadingScreenView
	{
		#region SERIALIZABLE FIELDS
		[SerializeField] private Transform loadingScreen;
		[SerializeField] private Canvas canvas;
		[SerializeField] private Slider loadingSlider;
		[SerializeField] private TMP_Text loadingText;

		[Header("DOTWeen")]
		[SerializeField] private float tweeningLength = 0.3f;
		#endregion

		#region FIELDS
		[Inject] private ILoadScenePresenter loadScenePresenter;
		#endregion

		private void Start()
		{
			transform.localScale = Vector3.zero;
			loadingText.text = $"Loading {0}%";
		}

		public Task Show()
		{
			canvas.gameObject.SetActive(true);
			Task showTask = loadingScreen.DOScale(new Vector3(1, 1), tweeningLength).AsyncWaitForCompletion();
			showTask.ContinueWith(obj => StartCoroutine(UpdateLoadingBar()));

			return showTask;
		}

		public Task Hide()
		{
			canvas.gameObject.SetActive(false);
			return loadingScreen.DOScale(Vector3.zero, tweeningLength).AsyncWaitForCompletion();
		}

		public IEnumerator UpdateLoadingBar()
		{
			float loadingPercents = 0;

			do
			{
				loadingPercents = loadScenePresenter.LoadingPercents;
				loadingText.text = $"Loading {loadingPercents * 100f}%";
				loadingSlider.value = loadingPercents;

				yield return null;

			} while (loadingPercents > 1);

		}
	}
}