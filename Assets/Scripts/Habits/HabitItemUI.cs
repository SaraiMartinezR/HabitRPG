using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HabitItemUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("UI Elements")]
    public TMP_Text habitNameText;
    public TMP_Text habitTypeText;
    public Button completeButton;
    public Image background; 

    private Habit habit;
    private PetStatsManager petStatsManager;
    private bool completed = false;

    /// <summary>
    /// Configura el UI del hábito con sus datos y referencia al PetStatsManager.
    /// </summary>
    public void Setup(Habit habit, PetStatsManager statsManager)
    {
        this.habit = habit;
        this.petStatsManager = statsManager;

        if (habitNameText != null)
            habitNameText.text = habit.name;

        if (habitTypeText != null)
            habitTypeText.text = $"Tipo: {habit.type} (+{habit.xpReward} XP)";

        // Asegurar botón limpio
        completeButton.onClick.RemoveAllListeners();
        completeButton.onClick.AddListener(CompleteHabit);

        // Reactivar por si fue completado antes
        completeButton.interactable = true;
        completed = false;

        // Color inicial del fondo
        if (background != null)
            background.color = new Color(1f, 1f, 1f, 0.1f);
    }

    /// <summary>
    /// Acción al completar el hábito.
    /// </summary>
    private void CompleteHabit()
    {
        if (completed) return; // Evitar doble clic

        completed = true;
        completeButton.interactable = false;

        Debug.Log($"Hábito completado: {habit.name} → {habit.type} +{habit.xpReward} XP");

        // Actualizar estadísticas globales (usando Singleton si está disponible)
        if (petStatsManager != null)
        {
            petStatsManager.AddStat(habit.type, habit.xpReward);
        }
        else if (PetStatsManager.Instance != null)
        {
            PetStatsManager.Instance.AddStat(habit.type, habit.xpReward);
        }
        else
        {
            Debug.LogWarning("No se encontró PetStatsManager.");
        }

        // Feedback visual (oscurecer el fondo o cambiar color)
        if (background != null)
            background.color = new Color(0.7f, 1f, 0.7f, 0.4f);

        // Opcional: efecto de texto
        if (habitNameText != null)
            habitNameText.text += " ✔";
    }

    /// <summary>
    /// Efecto visual al pasar el ratón (hover)
    /// </summary>
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (background != null && !completed)
            background.color = new Color(0.8f, 0.8f, 1f, 0.3f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (background != null && !completed)
            background.color = new Color(1f, 1f, 1f, 0.1f);
    }
}
