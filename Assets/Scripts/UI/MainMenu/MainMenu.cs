using System;
using UnityEngine;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private CanvasGroup _fadeGroup;
    [SerializeField] private float _fadeInSpeed;

    private void Start()
    {
        _fadeGroup.alpha = 1;
    }

    private void Update()
    {
        _fadeGroup.alpha = 1 - Time.timeSinceLevelLoad * _fadeInSpeed;
    }
}
