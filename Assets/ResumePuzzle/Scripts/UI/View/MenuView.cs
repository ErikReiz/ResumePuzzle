using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;
using ResumePuzzle.Interfaces;
using Zenject;

namespace ResumePuzzle.UI.View
{
	public class MenuView : MonoBehaviour, IView
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
		[Inject] private IMenuPresenter menuPresenter;
		#endregion

		private void OnEnable()
		{
			playGameButton.onClick.AddListener(menuPresenter.StartGame);
			settingsButton.onClick.AddListener(menuPresenter.OpenSettings);
			playGameButton.onClick.AddListener(menuPresenter.QuitGame);
		}

		private void OnDisable()
		{
			playGameButton.onClick.RemoveListener(menuPresenter.StartGame);
			settingsButton.onClick.RemoveListener(menuPresenter.OpenSettings);
			playGameButton.onClick.RemoveListener(menuPresenter.QuitGame);
		}

		public async void Show()
		{
			await transform.DOLocalMoveX(0, tweeningLength).AsyncWaitForCompletion();
		}

		public async void Hide()
		{
			await transform.DOLocalMoveX(IView.offScreenCoordinates, tweeningLength).AsyncWaitForCompletion();
		}
	}
}