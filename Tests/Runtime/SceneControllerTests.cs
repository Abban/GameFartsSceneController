using System.Collections;
using GF.Library.SceneController.TestResources;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace GF.Library.SceneController.Tests
{
    public class SceneControllerTests
    {
        private SceneControllerTestScenes _testScenes;
        private MockSceneTransition _transition;

        [SetUp]
        public void SetUp()
        {
            _testScenes = Resources.Load<SceneControllerTestScenes>(nameof(SceneControllerTestScenes));
            _transition = new MockSceneTransition();
        }
        
        
        [UnityTest]
        public IEnumerator OnLoadScene_LoadsScene()
        {
            var sceneToLoad = _testScenes.ReloadableTestScene;
            var loadedScene = string.Empty;
            var sceneController = new SceneController(_transition, _testScenes.DefaultTestScene);

            SceneManager.sceneLoaded += (scene, mode) => loadedScene = scene.name;

            yield return sceneController.LoadScene(sceneToLoad);

            Assert.AreEqual(sceneToLoad.SceneName, loadedScene);
        }
        
        
        [UnityTest]
        public IEnumerator OnLoadScene_InvokesSceneChangedAction()
        {
            var sceneToLoad = _testScenes.ReloadableTestScene;
            ISceneReference loadedScene = null;
            var sceneController = new SceneController(_transition, _testScenes.DefaultTestScene);

            sceneController.SceneChanged += scene => loadedScene = scene;

            yield return sceneController.LoadScene(_testScenes.ReloadableTestScene);

            Assert.AreEqual(sceneToLoad, loadedScene);
        }
        
        
        [UnityTest]
        public IEnumerator OnLoadSameSceneNotReloadable_DoesNotLoadScene()
        {
            var sceneThatDoesNotReload = _testScenes.DefaultTestScene;
            var counter = 0;
            var sceneController = new SceneController(_transition, sceneThatDoesNotReload);
            
            sceneController.SceneChanged += scene => counter++;
            SceneManager.sceneLoaded += (scene, mode) => counter++;

            yield return sceneController.LoadScene(sceneThatDoesNotReload);

            Assert.Zero(counter);
        }
        
        
        [UnityTest]
        public IEnumerator OnLoadSameSceneReloadable_ReloadsScene()
        {
            var reloadableScene = _testScenes.ReloadableTestScene;
            var counter = 0;
            var sceneController = new SceneController(_transition, reloadableScene);
            
            sceneController.SceneChanged += scene => counter++;
            SceneManager.sceneLoaded += (scene, mode) => counter++;

            yield return sceneController.LoadScene(reloadableScene);

            Assert.AreEqual(2, counter);
        }
        
        
        [UnityTest]
        public IEnumerator OnLoadSceneWithTransitionShowOnly_ShowsTransition()
        {
            var sceneController = new SceneController(_transition, _testScenes.DefaultTestScene);
            
            yield return sceneController.LoadScene(_testScenes.ReloadableTestScene, TransitionType.ShowOnly);

            Assert.AreEqual(1, _transition.ShownCount);
        }
        
        
        [UnityTest]
        public IEnumerator OnHideTransition_HidesTransition()
        {
            var sceneController = new SceneController(_transition, _testScenes.DefaultTestScene);
            
            yield return sceneController.LoadScene(_testScenes.ReloadableTestScene, TransitionType.ShowOnly);
            yield return sceneController.HideTransition();
            
            Assert.AreEqual(1, _transition.HiddenCount);
        }
        
        
        [UnityTest]
        public IEnumerator OnLoadSceneWithTransitionShowAndHide_ShowsAndHidesTransition()
        {
            var sceneController = new SceneController(_transition, _testScenes.DefaultTestScene);
            
            yield return sceneController.LoadScene(_testScenes.ReloadableTestScene, TransitionType.ShowAndHide);

            Assert.AreEqual(1, _transition.ShownCount);
            Assert.AreEqual(1, _transition.HiddenCount);
        }
        
        
        [UnityTest]
        public IEnumerator OnLoadSceneWithTransitionNone_DoesNotShowHideTransition()
        {
            var sceneController = new SceneController(_transition, _testScenes.DefaultTestScene);
            
            yield return sceneController.LoadScene(_testScenes.ReloadableTestScene, TransitionType.None);

            Assert.Zero(_transition.ShownCount);
            Assert.Zero(_transition.HiddenCount);
        }

        
        [UnityTest]
        public IEnumerator OnLoadScene_CallsLoadingStateChangedActionWithCorrectStates()
        {
            var loadingState = LoadingState.Idle;
            var sceneController = new SceneController(_transition, _testScenes.DefaultTestScene);

            sceneController.LoadingStateChanged += state => loadingState = state;

            yield return sceneController.LoadScene(_testScenes.ReloadableTestScene, TransitionType.ShowOnly);

            Assert.AreEqual(LoadingState.Loading, loadingState);

            yield return sceneController.HideTransition();
            
            Assert.AreEqual(LoadingState.Idle, loadingState);
        }
    }
}
