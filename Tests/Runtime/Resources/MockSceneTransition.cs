using System.Collections;

namespace GF.Library.SceneTransition.TestResources
{
    public class MockSceneTransition : ISceneTransition
    {
        public bool IsVisible { get; } = false;
        public int ShownCount { get; private set; }
        public int HiddenCount { get; private set; }

        public IEnumerator Show()
        {
            ShownCount++;
            yield return null;
        }

        public IEnumerator Hide()
        {
            HiddenCount++;
            yield return null;
        }
    }
}