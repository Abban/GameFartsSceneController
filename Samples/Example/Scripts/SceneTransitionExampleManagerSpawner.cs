using UnityEngine;

namespace GF.SceneTransition.Example
{
    public class SceneTransitionExampleManagerSpawner : MonoBehaviour
    {
        [SerializeField] private SceneTransitionExampleManager sceneTransitionExampleManagerPrefab = null;
        
        private void Awake()
        {
            var sceneTransitionManagerExample = FindObjectOfType<SceneTransitionExampleManager>();

            if (sceneTransitionManagerExample == null)
            {
                Instantiate(sceneTransitionExampleManagerPrefab);
            }
        }
    }
}