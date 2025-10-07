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

    [Header("Level & XP")]
    public int level = 1;
    public TMP_Text levelLabel;

    [Header("UI References")]
    public Image healthFill;
    public TMP_Text healthLabel;

    public Image strengthFill;
    public TMP_Text strengthLabel;

    public Image intelligenceFill;
    public TMP_Text intelligenceLabel;

    // Singleton
    private static PetStatsManager instance;
    public static PetStatsManager Instance => instance;

    void Awake()
    {
        // Asegurarse de que solo haya una instancia y persista entre escenas
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        health = 0;
        strength = 0;
        intelligence = 0;
        UpdateUI(); // esto fuerza a que las barras empiecen vacías
    }


    public void AddStat(string stat, int amount)
    {
        switch (stat)
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
            default:
                Debug.LogWarning($"Tipo de stat no reconocido: {stat}");
                break;
        }

        UpdateLevel();
        UpdateUI();
    }

    private void UpdateLevel()
    {
        int totalXP = health + strength + intelligence;
        level = 1 + (totalXP / 100); // sube un nivel cada 100 puntos combinados
    }

    private void UpdateUI()
    {
        // Salud
        if (healthFill != null)
        {
            healthFill.fillAmount = (float)health / maxHealth;
            healthLabel.text = $"Salud: {health}/{maxHealth}";
        }

        // Fuerza
        if (strengthFill != null)
        {
            strengthFill.fillAmount = (float)strength / maxStrength;
            strengthLabel.text = $"Fuerza: {strength}/{maxStrength}";
        }

        // Inteligencia
        if (intelligenceFill != null)
        {
            intelligenceFill.fillAmount = (float)intelligence / maxIntelligence;
            intelligenceLabel.text = $"Inteligencia: {intelligence}/{maxIntelligence}";
        }

        // Nivel
        if (levelLabel != null)
        {
            levelLabel.text = $"Nivel {level}";
        }
    }
}
