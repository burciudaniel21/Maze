using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public int playerHealth = 100;

    void Start()
    {
        UpdateHealth();
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        UpdateHealth();
    }

    [ContextMenu("UpdateHealth")]
    void UpdateHealth()
    {
        healthText.text = "Health: " + playerHealth.ToString();
        if (playerHealth <= 0) { GameManager.Instance.gameOver = true; }
    }
}
