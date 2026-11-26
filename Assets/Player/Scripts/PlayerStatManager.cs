using UnityEngine;

[CreateAssetMenu(fileName = "PlayerQuotaManager", menuName = "Scriptable Objects/PlayerQuotaManager")]
public class PlayerStatManager : ScriptableObject
{
    public static int FishesCaught = 0;
    public static int Health = 10;
    public static int QuotaGoal = 2;
    public static int CurrentDay = 1;
    public static int DayCount = 5;

    public static bool CatchFish()
    {
        if (FishesCaught >= QuotaGoal)
        {
            CurrentDay++;
            FishesCaught = 0;
            QuotaGoal += 2;
            Debug.Log("Quota Reached");
            Save();
            return true;
        }
        return false;
    }

    public static void Save()
    {
        PlayerPrefs.SetInt("CurrentDay",CurrentDay);
        PlayerPrefs.Save();
        Debug.Log("saved");
    }
    public static void Load()
    {
        CurrentDay = PlayerPrefs.GetInt("CurrentDay",1);
        Debug.Log("loaded");
        QuotaGoal = 2 * CurrentDay;
    }

    public static void Reset()
    {
        FishesCaught = 0;
        Health = 10;
        QuotaGoal = 2;
        CurrentDay = 1;
        DayCount = 5;
    }
}
