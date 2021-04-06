using System.Collections;
using GF.Library.SceneController;
using UnityEngine;

namespace GF.SceneTransition.Example
{
    public class SceneTransition : MonoBehaviour, ISceneTransition
    {
        [SerializeField] private CanvasGroup canvasGroup = null;
        public bool IsVisible => canvasGroup.alpha > 0;

        private const float FadeTime = 0.2f;

        private void Awake()
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }

        public IEnumerator Show()
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            
            yield return StartCoroutine(Fade(0f, 1f));
        }

        public IEnumerator Hide()
        {
            yield return StartCoroutine(Fade(1f, 0f));
            
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }


        private IEnumerator Fade(float from, float to)
        {
            var delta = 0f;
            
            while(delta <= FadeTime)
            {
                delta += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(from, to, delta / FadeTime);
                yield return null;
            }

            canvasGroup.alpha = to;
        }
    }
}