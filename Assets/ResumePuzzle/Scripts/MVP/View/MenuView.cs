using Zenject;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using ResumePuzzle.Interfaces;
using System.Threading.Tasks;

namespace ResumePuzzle.UI.View
{
	public class MenuView : MonoBehaviour, IMenuView
	{
		#region SERIALIZABLE FIELDS
		[Header("Button")]
		[SerializeField] private Button playGameButton;
		[SerializeField] private Button settingsButton;
		[SerializeField] private Button quitGameButton;

		[Header("DOTWeen")]
		[SerializeField] private float tweeningLength = 0.3f;
		#endregion

		#region FIELDS
		[Inject] private Canvas canvas;
		[Inject] private IMenuPresenter menuPresenter;
		#endregion

		private void OnEnable()
		{
			playGameButton.onClick.AddListener(menuPresenter.StartGame);
			settingsButton.onClick.AddListener(menuPresenter.OpenSettings);
			quitGameButton.onClick.AddListener(menuPresenter.QuitGame);
		}

		private void OnDisable()
		{
			playGameButton.onClick.RemoveListener(menuPresenter.StartGame);
			settingsButton.onClick.RemoveListener(menuPresenter.OpenSettings);
			quitGameButton.onClick.RemoveListener(menuPresenter.QuitGame);
		}

		public Task Show()
		{
			return transform.DOLocalMoveX(0, tweeningLength).AsyncWaitForCompletion();
		}

		public Task Hide()
		{
			return transform.DOLocalMoveX(IView.offScreenCoordinates, tweeningLength).AsyncWaitForCompletion();
		}

		public void ShowCanvas()
		{
			canvas.gameObject.SetActive(true);
		}

		public void HideCanvas()
		{
			canvas.gameObject.SetActive(false);
		}
	}
}