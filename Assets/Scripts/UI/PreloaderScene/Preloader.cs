using UnityEngine;
using UnityEngine.SceneManagement;


public sealed class Preloader : MonoBehaviour
{
    private CanvasGroup _fadeGroup;
    private float _loadTime;
    private float _minLogoTime = 3;

    private void Start()
    {
        _fadeGroup = FindObjectOfType<CanvasGroup>();

        _fadeGroup.alpha = 1;
        
        //Preload data by Task here. Get _loadTime
        //_loadTime = 0;

        if (Time.time < _minLogoTime)
        {
            _loadTime = _minLogoTime;
        }
        else
        {
            _loadTime = Time.time; 
        }

    }

    private void Update()
    {
        if (Time.time < _minLogoTime)
        {
            _fadeGroup.alpha = 1 - Time.time;
        }

        if (Time.time > _minLogoTime && _loadTime != 0)
        {
            _fadeGroup.alpha = Time.time - _minLogoTime;
            if (_fadeGroup.alpha >= 1)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
