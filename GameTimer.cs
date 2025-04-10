using UnityEngine;
using TMPro; // Importa o namespace do TextMeshPro

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;         // Exibe o tempo em tempo real
    public TextMeshProUGUI endGameTimerText;    // Exibe o tempo final no painel de fim de jogo
    public TextMeshProUGUI highscoreText;       // Exibe o highscore (menor tempo)

    private float timeElapsed = 0f;
    private bool gameEnded = false;
    private float highscore;

    void Start()
    {
        // Recupera o highscore salvo ou define como float.MaxValue se não houver highscore salvo
        highscore = PlayerPrefs.GetFloat("Highscore", float.MaxValue);

        // Se o valor recuperado for 0, trate-o como nenhum highscore válido
        if (highscore == 0f)
        {
            highscore = float.MaxValue;
        }
    }

    void Update()
    {
        if (!gameEnded)
        {
            timeElapsed += Time.deltaTime;
            timerText.text = "Tempo: " + timeElapsed.ToString("F2");
        }
    }

    public void EndTimer()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            endGameTimerText.text = "Tempo Final: " + timeElapsed.ToString("F2");

            // Atualiza o highscore se o tempo atual for menor que o highscore salvo
            if (timeElapsed < highscore)
            {
                highscore = timeElapsed;
                PlayerPrefs.SetFloat("Highscore", highscore);
            }

            highscoreText.text = "Highscore (Menor Tempo): " + (highscore == float.MaxValue ? "N/A" : highscore.ToString("F2"));
        }
    }
}
