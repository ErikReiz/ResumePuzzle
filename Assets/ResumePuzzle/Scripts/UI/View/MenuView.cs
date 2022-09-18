using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;
using ResumePuzzle.Interfaces;

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

		#region PROPERTIES
		public UnityAction OnPlayButtonClicked { set { playGameButton.onClick.AddListener(value); } }
		public UnityAction OnSettingsButtonClicked { set { settingsButton.onClick.AddListener(value); } }
		public UnityAction OnQuitButtonClicked { set { quitGameButton.onClick.AddListener(value); } }
		#endregion

		private void OnDisable()
		{
			playGameButton.onClick.RemoveAllListeners();
			settingsButton.onClick.RemoveAllListeners();
			quitGameButton.onClick.RemoveAllListeners();
		}

		public async void Show()
		{
			gameObject.SetActive(true);
			await transform.DOLocalMoveX(0, tweeningLength).AsyncWaitForCompletion();
		}

		public async void Hide()
		{
			await transform.DOLocalMoveX(IView.offScreenCoordinates, tweeningLength).AsyncWaitForCompletion();
			gameObject.SetActive(false);
		}
	}
}