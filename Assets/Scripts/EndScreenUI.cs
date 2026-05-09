using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winnerText;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        int p1 = GameManager.Instance.p1Wins;
        int p2 = GameManager.Instance.p2Wins;

        string winner = p1 > p2 ? "Oyuncu 1 Kazandý!" : "Oyuncu 2 Kazandý!";
        winnerText.text = winner;
        scoreText.text = $"{p1} - {p2}";
    }

    public void PlayAgain()
    {
        // Skorlarý sýfýrla
        GameManager.Instance.p1Wins = 0;
        GameManager.Instance.p2Wins = 0;
        GameManager.Instance.currentRound = 1;
        SceneManager.LoadScene(0); // Baþa dön
    }
}
