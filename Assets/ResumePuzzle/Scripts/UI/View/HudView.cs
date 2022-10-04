using Zenject;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using ResumePuzzle.Interfaces;
using System.Threading.Tasks;

namespace ResumePuzzle.UI.View
{
	public class HudView : MonoBehaviour, IView
	{
		#region SERIALIZABLE FIELDS
		[Header("Button")]
		[SerializeField] private Button pauseButton;
		#endregion

		#region FIELDS
		[Inject] private Canvas canvas;
		[Inject] private IHudPresenter hudPresenter;
		#endregion

		private void OnEnable()
		{
			pauseButton.onClick.AddListener(hudPresenter.PauseGame);
		}

		private void OnDisable()
		{
			pauseButton.onClick.RemoveListener(hudPresenter.PauseGame);
		}

		public Task Show()
		{
			return null;
		}

		public Task Hide()
		{
			return null;
		}
	}
}