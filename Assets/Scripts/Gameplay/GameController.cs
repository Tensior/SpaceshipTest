using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

namespace Gameplay
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance;

        [SerializeField]
        private Text _scoreText;

        [SerializeField]
        private Text _playerHealthText;

        [SerializeField]
        private GameObject _gameArea;

        [SerializeField]
        private GameObject _gameOverUI;

        [SerializeField]
        private Text _finalScoreText;

        private int _scoreAmount = 0;

        private void Awake()
        {
            if ( Instance == null )
            {
                Instance = this;
            }
            else if ( Instance != this )
            {
                Destroy( gameObject );
            }

        }

        private void Start()
        {
            _scoreAmount = 0;
            UpdateScore( 0 );
        }

        private void Update()
        {

        }

        public void UpdateScore( int addValue )
        {
            _scoreAmount += addValue;
            _scoreText.text = "Score: " + _scoreAmount;
        }

        public void UpdatePlayerHealth( float currentHealth, float maxHealth )
        {
            _playerHealthText.text = currentHealth + " / " + maxHealth + " health";
        }

        public void RestartGame()
        {
            SceneManager.LoadScene( SceneManager.GetActiveScene().name );
        }

        public void GameOver()
        {
            _gameArea.SetActive( false );

            _gameOverUI.SetActive( true );
            _finalScoreText.text = "Final score: " + _scoreAmount;
        }
    }
}
