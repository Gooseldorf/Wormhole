using UnityEngine;


[CreateAssetMenu(menuName = "My Assets/" + Constants.SCORE_MODEL)]
public sealed class ScoreModel : ScriptableObject
{
    private int _asteroidsDestroyed = 0;
    private float _gameTime = 0;


    public int AsteroidsDestroyed
    {
        get => _asteroidsDestroyed;
        set => _asteroidsDestroyed = value;
    }

    public float GameTime
    {
        get => _gameTime;
        set => _gameTime = value;
    }
}
