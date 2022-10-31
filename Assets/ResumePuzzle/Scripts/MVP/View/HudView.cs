using ResumePuzzle.Interfaces;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ResumePuzzle.UI.View
{
	public class HudView : MonoBehaviour, IView
	{
		#region SERIALIZABLE FIELDS
		[Header("Button")]
		[SerializeField] private Button pauseButton;
		[SerializeField] private Button interactButton;
		#endregion

		#region FIELDS
		[Inject] private Canvas canvas;
		[Inject] private IHudPresenter hudPresenter;
		#endregion

		private void OnEnable()
		{
			pauseButton.onClick.AddListener(hudPresenter.PauseGame);
			interactButton.onClick.AddListener(hudPresenter.Interact);
		}

		private void OnDisable()
		{
			pauseButton.onClick.RemoveListener(hudPresenter.PauseGame);
			interactButton.onClick.RemoveListener(hudPresenter.Interact);
		}

		public Task Show()
		{
			canvas.gameObject.SetActive(true);
			return null;
		}

		public Task Hide()
		{
			canvas.gameObject.SetActive(false);
			return null;
		}
	}
}