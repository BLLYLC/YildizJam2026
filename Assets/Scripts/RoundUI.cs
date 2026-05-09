using TMPro;
using UnityEngine;

public class RoundUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI roundText;

    private void Start()
    {
        roundText.text = $"Round {GameManager.Instance.currentRound}";
    }
}