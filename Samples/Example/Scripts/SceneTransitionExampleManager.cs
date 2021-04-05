using GF.Library.SceneTransition;
using UnityEngine;

namespace GF.SceneTransition.Example
{
    public class SceneTransitionExampleManager : MonoBehaviour
    {
        [SerializeField] private SceneTransition sceneTransition = null;
        [SerializeField] private SceneReference scene1 = null;
        [SerializeField] private SceneReference scene2 = null;

        private ISceneTransitionController _sceneTransitionController;


        private void Awake()
        {
            _sceneTransitionController = new SceneTransitionController(sceneTransition, scene1);
            _sceneTransitionController.SceneChanged += OnSceneChanged;
            _sceneTransitionController.LoadingStateChanged += OnLoadingStateChanged;
        }

        
        private void OnDisable()
        {
            _sceneTransitionController.SceneChanged -= OnSceneChanged;
            _sceneTransitionController.LoadingStateChanged -= OnLoadingStateChanged;
        }

        
        public void Start()
        {
            DontDestroyOnLoad(gameObject);
        }


        public void LoadScene1()
        {
            StartCoroutine(_sceneTransitionController.LoadScene(scene1, TransitionType.ShowAndHide));
        }
        
        
        public void LoadScene2()
        {
            StartCoroutine(_sceneTransitionController.LoadScene(scene2, TransitionType.ShowAndHide));
        }


        private static void OnSceneChanged(ISceneReference sceneReference)
        {
            Debug.Log($"Scene changed to {sceneReference.SceneName}");
        }


        private static void OnLoadingStateChanged(LoadingState loadingState)
        {
            Debug.Log($"LoadingState changed to {loadingState}");
        }
    }
}