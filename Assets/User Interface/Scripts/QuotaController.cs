using TMPro;
using UnityEngine;

public class QuotaController : MonoBehaviour
{
    public int currentQuota;

    void Start()
    {
        currentQuota = PlayerStatManager.FishesCaught;
        Debug.Log(currentQuota);
        GetComponent<TMP_Text>().text = currentQuota.ToString()+"/"+PlayerStatManager.QuotaGoal;
    }
    
    public void Quota()
    {
    }


}
