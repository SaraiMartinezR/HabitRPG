using UnityEngine;
[System.Serializable]
public class Habit
{
    // Nombre del hábito (por ejemplo: "Correr", "Leer", "Meditar")
    public string name;

    // Tipo de hábito (por ejemplo: "Health", "Strength", "Intelligence")
    public string type;

    // Recompensa de experiencia (XP) que se obtiene al completar el hábito
    public int xpReward;

    // Constructor que inicializa un nuevo hábito con los valores dados
    public Habit(string name, string type, int xpReward)
    {
        this.name = name;         // Asigna el nombre del hábito
        this.type = type;         // Asigna el tipo de hábito
        this.xpReward = xpReward; // Asigna la cantidad de XP que otorga
    }
}
