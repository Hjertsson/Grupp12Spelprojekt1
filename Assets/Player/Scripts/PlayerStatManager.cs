using UnityEngine;

[CreateAssetMenu(fileName = "PlayerQuotaManager", menuName = "Scriptable Objects/PlayerQuotaManager")]
public class PlayerStatManager : ScriptableObject
{
    public static int FishesCaught = 0;
    public static int Health = 10;
    public static int QuotaGoal = 1;
    public static int CurrentDay = 1;
    public static int DayCount = 5;

    public static bool CatchFish()
    {
        FishesCaught++;
        if (FishesCaught >= QuotaGoal)
        {
            CurrentDay++;
            FishesCaught = 0;
            QuotaGoal += 2;
            Debug.Log("Quota Reached");
            return true;
        }
        return false;
    }
    
}
