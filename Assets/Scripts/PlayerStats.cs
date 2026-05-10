using Unity.VisualScripting;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private int playerID;

    private float currentHealth;
    public HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetSliderMax(maxHealth);
    }

    public void TakeDamage(float amount)
    {
        Shield shield = GetComponentInChildren<Shield>();
        if (shield != null && shield.IsBlocking())
        {
            Debug.Log("Hasar bloklandi!");
            return; // Hasar alma
        }

        currentHealth -= amount;
        currentHealth = Mathf.Max(0, currentHealth);
        healthBar.SetSlider(currentHealth);


        if (currentHealth <= 0)
        {
            GameManager.Instance.RoundOver(playerID);
        }

        if (currentHealth <= 0)
        {
            print(playerID + "Öldü");
            GameManager.Instance.RoundOver(playerID);
        }    
    }    
    public int GetPlayerId()
    {
        return playerID;
    }
}
