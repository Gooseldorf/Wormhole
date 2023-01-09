using System.Collections;
using Data;
using DG.Tweening;
using Shield.Data;
using UnityEngine;
using UnityEngine.Rendering;
using SceneManager = Managers.SceneManager;

public class GameStateController : MonoBehaviour
{
   [SerializeField] private Volume _postProcessing;
   [SerializeField] private ScoreModel _score;
   [SerializeField] private ShieldHp _hp;
   [SerializeField] private ShieldData _shieldData;
   [SerializeField] private AudioSource _backgroundMusic;
   [SerializeField] private AudioClip _explosion;
   [SerializeField] private GameObject _pauseScreen;
   [SerializeField] private CanvasGroup _fadeCanvas;
   [SerializeField] private AsteroidData _asteroidData;
   private bool _isLastDamage;
   private float _timer;
   
   public static bool IsGameStart;
   public static bool IsGamePaused;
   public static bool IsGameResumed;
   public static bool IsGameFinish;
   public static bool IsGameEnd;

   private bool _levelUp;

   private void Start()
   {
      IsGameStart = true;
      Time.timeScale = 1;
      _timer = 0;
      _hp.OnValueChange += CheckIfGameEnd;
   }

   private void Update()
   {
      _timer += Time.deltaTime;
      if (_timer > 388)
      {
         FinishGame();
      }

      if (_timer is > 100 and < 200)
      {
         _asteroidData.StartSpawnAmount = 5;
         _asteroidData.SpawnTime = 2.8f;
      }
      
      if (_timer is > 200 and < 300)
      {
         _asteroidData.StartSpawnAmount = 6;
         _asteroidData.SpawnTime = 2.6f;
      }
      
      if (_timer is > 300 and < 380)
      {
         _asteroidData.StartSpawnAmount = 6;
         _asteroidData.SpawnTime = 2.4f;
      }

      if (_timer > 380)
      {
         _asteroidData.StartSpawnAmount = 6;
      }
      
      
      if (IsGameStart)
      {
         IsGameStart = false;
         StartGame();
      }

      if (IsGameFinish)
      {
         IsGameFinish = false;
         FinishGame();
      }

      if (IsGameEnd)
      {
         IsGameEnd = false;
         EndGame();
      } 
      
      if (IsGamePaused)
      {
         IsGamePaused = false;
         PauseGame();
      }    
      
      if (IsGameResumed)
      {
         IsGameResumed = false;
         ResumeGame();
      }
   }

   private void StartGame()
   {
      _score.AsteroidsDestroyed = 0;
      _score.GameTime = 0;
      _hp.CurrentShieldHp = _shieldData.ShieldStartHp;
      StartCoroutine(StartGameWithFadeScreen());
   }
   
   private void PauseGame()
   {
      _backgroundMusic.Pause();
      _pauseScreen.gameObject.SetActive(true);
      Time.timeScale = 0;
   }
   
   public void ResumeGame()
   {
      _backgroundMusic.Play();
      _pauseScreen.gameObject.SetActive(false);
      Time.timeScale = 1;

   }
   
   private void FinishGame()
   {
      StartCoroutine(ToMainMenu());
   }

   private void EndGame()
   {
      StartCoroutine(ToMainMenu());
   }

   public void Quit()
   {
      _score.AsteroidsDestroyed = 0;
      _score.GameTime = 0;
      _hp.CurrentShieldHp = _shieldData.ShieldStartHp;
      Time.timeScale = 1;
      StartCoroutine(ToMainMenu());
   }

   private void CheckIfGameEnd()
   {
      if (_hp.CurrentShieldHp < 1 && _isLastDamage)
      {
         _backgroundMusic.PlayOneShot(_explosion);
         StartCoroutine(ToMainMenu());
      }
      else if (_hp.CurrentShieldHp < 1)
      {
         _isLastDamage = true;
      }
      else
      {
         _isLastDamage = false;
      }
   }

   private IEnumerator ToMainMenu()
   {
      _asteroidData.StartSpawnAmount = 6;
      _asteroidData.SpawnTime = 2.4f;
      DOTween.To(() => _fadeCanvas.alpha, x => _fadeCanvas.alpha = x, 1, 2);
      yield return new WaitForSeconds(2);
      StopAllCoroutines();
      SceneManager.instance.ToMainMenu();
   }

   private IEnumerator StartGameWithFadeScreen()
   {
      DOTween.To(() => _fadeCanvas.alpha, x => _fadeCanvas.alpha = x, 0, 5);
      yield return new WaitForSeconds(5);
   }
}
