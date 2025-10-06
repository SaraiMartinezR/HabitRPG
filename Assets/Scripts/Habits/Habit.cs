using UnityEngine;

[System.Serializable]
public class Habit
{
    public string name;
    public string type; // "Health", "Strength", "Intelligence"
    public int xpReward;

    public Habit(string name, string type, int xpReward)
    {
        this.name = name;
        this.type = type;
        this.xpReward = xpReward;
    }
}
