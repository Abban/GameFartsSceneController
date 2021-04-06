namespace GF.Library.SceneController
{
    public interface ISceneReference
    {
        string SceneName { get; }
        bool Reloadable { get; }
    }
}