using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PetStatsManager : MonoBehaviour
{
    [Header("Stat values")]
    public int health = 0;
    public int strength = 0;
    public int intelligence = 0;

    [Header("Max values")]
    public int maxHealth = 100;
    public int maxStrength = 100;
    public int maxIntelligence = 100;

    [Header("UI References")]
    public Image healthFill;
    public TMP_Text healthLabel;

    public Image strengthFill;
    public TMP_Text strengthLabel;

    public Image intelligenceFill;
    public TMP_Text intelligenceLabel;

    void Start()
    {
        UpdateUI();
    }

    public void AddStat(string stat, int amount)
    {
        switch(stat)
        {
            case "Health":
                health = Mathf.Clamp(health + amount, 0, maxHealth);
                break;
            case "Strength":
                strength = Mathf.Clamp(strength + amount, 0, maxStrength);
                break;
            case "Intelligence":
                intelligence = Mathf.Clamp(intelligence + amount, 0, maxIntelligence);
                break;
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        // Salud
        healthFill.fillAmount = (float)health / maxHealth;
        healthLabel.text = $"Salud: {health}/{maxHealth}";

        // Fuerza
        strengthFill.fillAmount = (float)strength / maxStrength;
        strengthLabel.text = $"Fuerza: {strength}/{maxStrength}";

        // Inteligencia
        intelligenceFill.fillAmount = (float)intelligence / maxIntelligence;
        intelligenceLabel.text = $"Inteligencia: {intelligence}/{maxIntelligence}";
    }
}
