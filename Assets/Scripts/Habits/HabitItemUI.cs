using UnityEngine;
using TMPro;
using UnityEngine.UI;

// IMPORTANTE: la clase debe heredar de MonoBehaviour
public class HabitItemUI : MonoBehaviour
{
    public TMP_Text habitNameText;
    public TMP_Text habitTypeText;
    public Button completeButton;

    private Habit habit;
    private PetStatsManager petStatsManager;

    public void Setup(Habit habit, PetStatsManager statsManager)
    {
        this.habit = habit;
        this.petStatsManager = statsManager;

        habitNameText.text = habit.name;
        habitTypeText.text = $"Tipo: {habit.type} (+{habit.xpReward} XP)";

        completeButton.onClick.RemoveAllListeners();
        completeButton.onClick.AddListener(() =>
        {
            CompleteHabit();
        });
    }

    void CompleteHabit()
    {
        Debug.Log($"Completado: {habit.name} → {habit.type} +{habit.xpReward} XP");
        if(petStatsManager != null)
            petStatsManager.AddStat(habit.type, habit.xpReward);

        // Opcional: desactivar el botón tras completarlo
        completeButton.interactable = false;
    }
}
