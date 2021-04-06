using GF.Library.SceneController;
using UnityEngine;

namespace GF.SceneTransition.Example
{
    public class SceneTransitionExampleManager : MonoBehaviour
    {
        [SerializeField] private SceneTransition sceneTransition = null;
        [SerializeField] private SceneReference scene1 = null;
        [SerializeField] private SceneReference scene2 = null;

        private ISceneController _sceneController;


        private void Awake()
        {
            _sceneController = new SceneController(sceneTransition, scene1);
            _sceneController.SceneChanged += OnSceneChanged;
            _sceneController.LoadingStateChanged += OnLoadingStateChanged;
        }

        
        private void OnDisable()
        {
            _sceneController.SceneChanged -= OnSceneChanged;
            _sceneController.LoadingStateChanged -= OnLoadingStateChanged;
        }

        
        public void Start()
        {
            DontDestroyOnLoad(gameObject);
        }


        public void LoadScene1()
        {
            StartCoroutine(_sceneController.LoadScene(scene1, TransitionType.ShowAndHide));
        }
        
        
        public void LoadScene2()
        {
            StartCoroutine(_sceneController.LoadScene(scene2, TransitionType.ShowAndHide));
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