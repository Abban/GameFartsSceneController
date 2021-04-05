using System.Collections;

namespace GF.Library.SceneTransition
{
    public interface ISceneTransition
    {
        bool IsVisible { get; }
        IEnumerator Show();
        IEnumerator Hide();
    }
}