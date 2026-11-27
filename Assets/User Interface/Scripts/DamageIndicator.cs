using UnityEngine;
using TMPro;

public class DamageIndicator : MonoBehaviour
{
    [SerializeField] private GameObject damageIndicator;
    private Animator damageIndicatorAnim;
    private TextMeshProUGUI damageIndicatorText;


    void Start()
    {
        damageIndicatorAnim = damageIndicator.GetComponent<Animator>();
        damageIndicatorText = damageIndicator.GetComponent<TextMeshProUGUI>();
    }
    public  void AttackIndicator(int damageInd)
    {
        damageIndicatorText.text = ("-" +damageInd);
        damageIndicatorAnim.SetTrigger("attacked");
            
    }
    public void MissedIndicator()
    {
        damageIndicatorText.text = ("Attack failed");
        damageIndicatorAnim.SetTrigger("attacked");
    }
}
