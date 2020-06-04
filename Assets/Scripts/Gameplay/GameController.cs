using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Gameplay.Spaceships;

namespace Gameplay
{
    // Singleton to control UI and gameover state
    public class GameController : MonoBehaviour
    {
        public static GameController Instance;

        [SerializeField]
        private Text _scoreText; //reference to text field for displaying current score

        [SerializeField]
        private Text _playerHealthText; //reference to text field for displaying current player health

        [SerializeField]
        private GameObject _gameArea; //parent object for all in-game entities, used to disable them on gameover

        [SerializeField]
        private GameObject _gameOverUI; //parent object for gameover UI, enabled on player death

        [SerializeField]
        private Text _finalScoreText; //reference to text field in gameover UI for displaying final score

        private int _scoreAmount = 0; //counter for current score

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

            Spaceship.OnEnemySpaceshipFullyDamaged += EnemySpaceshipFullyDamaged;
            Spaceship.OnPlayerSpaceshipFullyDamaged += GameOver;

        }

        private void Start()
        {
            _scoreAmount = 0;
            UpdateScore( 0 );
        }

        // Adds value to the current score and refreshes displayed text for score
        public void UpdateScore( int addValue )
        {
            _scoreAmount += addValue;
            _scoreText.text = "Score: " + _scoreAmount;
        }

        // Refreshes displayed text for player health
        public void UpdatePlayerHealth( float currentHealth, float maxHealth )
        {
            _playerHealthText.text = currentHealth + " / " + maxHealth + " health";
        }

        // Callback for enemy destroyed event, increases current score
        private void EnemySpaceshipFullyDamaged( Transform transform )
        {
            Instance.UpdateScore( 1 );
        }

        // Callback for player death, deactivates game area and shows gameover UI with final score
        private void GameOver()
        {
            _gameArea.SetActive( false );

            _gameOverUI.SetActive( true );
            _finalScoreText.text = "Final score: " + _scoreAmount;
        }

        // Callback for "Restart" button click, reloads current scene
        public void RestartGame()
        {
            SceneManager.LoadScene( SceneManager.GetActiveScene().name );
        }

        private void OnDisable()
        {
            Spaceship.OnEnemySpaceshipFullyDamaged -= EnemySpaceshipFullyDamaged;
            Spaceship.OnPlayerSpaceshipFullyDamaged -= GameOver;
        }
    }
}
