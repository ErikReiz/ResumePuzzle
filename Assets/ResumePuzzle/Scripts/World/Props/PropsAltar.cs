using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

namespace ResumePuzzle.World.Interactable
{
    public class PropsAltar : MonoBehaviour
    {
		#region SERIALIZABLE FIELDS
		[SerializeField] private List<SpriteRenderer> runes;

        [SerializeField] private Color startColor;
        [SerializeField] private Color finalColor;
        [SerializeField] private float curveLength = 0.5f;
		#endregion

        private void OnTriggerEnter2D(Collider2D other)
        {
            TurnRunes(true);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            TurnRunes(false);
        }

        private void TurnRunes(bool turnOn)
		{
            Color targetColor = turnOn ? finalColor : startColor;

            foreach (SpriteRenderer r in runes)
                r.DOColor(targetColor, curveLength);

		}
    }
}
