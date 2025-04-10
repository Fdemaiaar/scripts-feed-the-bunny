using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject endGamePanel;         // Painel de fim de jogo
    public AudioManager audioManager;         // Referência ao AudioManager
    public GameTimer gameTimer;               // Referência ao GameTimer
    public bool endSoundPlayed = false;       // Flag para tocar som apenas uma vez

    void FixedUpdate()
    {
        if (GameController.gameOver)
        {
            Debug.Log("Game Over detectado no UIManager.");
            if (!endSoundPlayed)
            {
                Debug.Log("Tentando tocar o som de fim de jogo.");
                audioManager.PlayEndGameSound();
                endSoundPlayed = true;
            }
            gameTimer.EndTimer();
            endGamePanel.SetActive(true);
        }
    }
}