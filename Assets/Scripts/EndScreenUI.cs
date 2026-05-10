using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winnerText;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        int p1 = GameManager.Instance.GetPlayerWins(0);
        int p2 = GameManager.Instance.GetPlayerWins(1);

        if (p1 > p2)
            winnerText.text = "Oyuncu 1 Kazandý!";
        else if (p2 > p1)
            winnerText.text = "Oyuncu 2 Kazandý!";
        else
            winnerText.text = "Berabere!";

        scoreText.text = $"{p1} - {p2}";
    }

    public void PlayAgain()
    {
        GameManager.Instance.ResetWins();
        
        SceneManager.LoadScene(0);
    }
}
