using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundAudio;  // AudioSource para a música de fundo
    public AudioSource endGameAudio;     // AudioSource para o som de fim de jogo

    void Start()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            if (backgroundAudio != null)
            {
                backgroundAudio.loop = true;
                backgroundAudio.Play();
            }
        }

        if (endGameAudio != null)
        {
            endGameAudio.playOnAwake = false;
            endGameAudio.loop = false;
            endGameAudio.Stop();
        }
    }

    public void PlayEndGameSound()
    {
        // Remova temporariamente a checagem de cena para teste
        if (endGameAudio != null)
        {
            Debug.Log("PlayEndGameSound chamada");
            endGameAudio.PlayOneShot(endGameAudio.clip);
        }
    }
}
