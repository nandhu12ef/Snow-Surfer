using UnityEngine;

[CreateAssetMenu(fileName = "Powerup", menuName = "Powerup")]
public class Powerup : ScriptableObject
{
    [SerializeField] string powerupType;
    [SerializeField] float valueChange;
    [SerializeField] float time;

    public string GetPowerupType()
    {
        return powerupType;
    }
    public float GetvalueChange()
    {
        return valueChange;
    }
    public float GetTime()
    {
        return time;
    }
    
}
