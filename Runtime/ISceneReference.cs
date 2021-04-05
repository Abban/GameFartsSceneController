namespace GF.Library.SceneTransition
{
    public interface ISceneReference
    {
        string SceneName { get; }
        bool Reloadable { get; }
    }
}