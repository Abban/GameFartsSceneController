using UnityEngine;

namespace GF.Library.SceneController.TestResources
{
    // [CreateAssetMenu(fileName = "TestScenes", menuName = "GF/Scene Controller/Test Scenes")]
    public class SceneControllerTestScenes : ScriptableObject
    {
        [SerializeField] private SceneReference defaultTestScene = null;
        [SerializeField] private SceneReference reloadableTestScene = null;

        public SceneReference DefaultTestScene => defaultTestScene;
        public SceneReference ReloadableTestScene => reloadableTestScene;
    }
}