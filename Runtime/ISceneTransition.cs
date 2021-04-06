using System.Collections;

namespace GF.Library.SceneController
{
    public interface ISceneTransition
    {
        bool IsVisible { get; }
        IEnumerator Show();
        IEnumerator Hide();
    }
}