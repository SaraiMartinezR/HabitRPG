using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HabitManager : MonoBehaviour
{
    [Header("UI Añadir Hábito")]
    public TMP_InputField habitNameInput;       // Input nombre
    public TMP_InputField habitXPInput;         // Input XP
    public TMP_Dropdown habitStatDropdown;      // Dropdown de stat
    public Button addHabitButton;               // Botón añadir
    public Button cancelButton;                 // Botón cancelar

    private List<Habit> habits = new List<Habit>();

    void Start()
    {
        // Conectar botones a funciones
        if (addHabitButton != null)
            addHabitButton.onClick.AddListener(OnAddHabitButtonClicked);

        if (cancelButton != null)
            cancelButton.onClick.AddListener(OnCancelAddHabit);

        // Agregamos hábitos de ejemplo
        AddHabit("Hacer ejercicio", "Strength", 10);
        AddHabit("Leer un libro", "Intelligence", 15);
        AddHabit("Dormir bien", "Health", 8);

        // Opcional: ordenar alfabéticamente
        habits.Sort((a, b) => a.name.CompareTo(b.name));

        // Si quieres mostrar los hábitos, aquí deberías usar tu nueva UI
        // pero ya no hay ScrollView ni items instanciados
    }

    // Función llamada al pulsar "Añadir" en la UI
    public void OnAddHabitButtonClicked()
    {
        string name = habitNameInput.text;
        string type = habitStatDropdown.options[habitStatDropdown.value].text;
        int xp = 0;

        if (!int.TryParse(habitXPInput.text, out xp))
        {
            Debug.LogWarning("XP inválida, usando 0");
        }

        if (string.IsNullOrEmpty(name))
        {
            Debug.LogWarning("Nombre del hábito vacío");
            return;
        }

        // Agregar hábito
        AddHabit(name, type, xp);

        // Limpiar inputs
        ClearHabitInputs();
    }

    // Función llamada al pulsar "Cancelar" en la UI
    public void OnCancelAddHabit()
    {
        ClearHabitInputs();
    }

    // Limpia los campos de entrada de la UI
    private void ClearHabitInputs()
    {
        habitNameInput.text = "";
        habitXPInput.text = "";
        habitStatDropdown.value = 0;
    }

    // Agrega un nuevo hábito a la lista
    public void AddHabit(string name, string type, int xpReward)
    {
        Habit newHabit = new Habit(name, type, xpReward);
        habits.Add(newHabit);

        // Aquí podrías llamar a tu nueva UI para mostrar los hábitos
        Debug.Log($"Hábito agregado: {name} ({type}) +{xpReward} XP");
    }
}
