using Interfaces;
using UnityEngine;
using Views;

public sealed class ScoreAdapter: IExecute
{
    private readonly ScoreModel _model;
    private readonly ScoreView _view;

    private float _minutes;
    private float _seconds;
    
    
    public ScoreAdapter(ScoreModel model, ScoreView view)
    {
        _model = model;
        _view = view;
        AsteroidView.OnAsteroidDestruction += UpdateAsteroidsCount;
    }

    public void Update()
    {
        _model.GameTime += Time.deltaTime;
        _minutes = Mathf.FloorToInt(_model.GameTime / 60);
        _seconds = Mathf.FloorToInt(_model.GameTime % 60);
        _view.Time.text = $"{_minutes:00}:{_seconds:00}";
    }

    private void UpdateAsteroidsCount(AsteroidView asteroid)
    {
        _model.AsteroidsDestroyed += 1;
        _view.Score.text = _model.AsteroidsDestroyed.ToString();
    }
}
