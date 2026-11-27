using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerCombatController : MonoBehaviour
{
    [SerializeField]
    FishManager fishManager;

    [SerializeField] private GameObject popUp;
    [SerializeField] private GameObject attackMenu;
    
    
    //För DamageIndicators, ta bort om ni vill göra något annat :)
    [SerializeField] private DamageIndicator playerAttackIndicator;
    [SerializeField] private DamageIndicator enemyDamageIndicator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    public void Attack1()
    {
       
        var died = fishManager.spawnedFishes[0].TakeDamage(1);
        //För DamageIndicators
        playerAttackIndicator.AttackIndicator(1);

            if (!died)
            {
                int damage = fishManager.spawnedFishes[0].Attack();
                PlayerStatManager.Health -= damage;
                Debug.Log("took "+damage+" damage");
                
                //För DamageIndicators
                enemyDamageIndicator.AttackIndicator(damage);
                if (PlayerStatManager.Health <= 0)
                {
                    PlayerStatManager.Reset();
                    SceneManager.LoadScene("GameOverScene");
                    Debug.Log("player died");
                    return;
                }
            }
            else
            {
                PlayerStatManager.FishesCaught++;
                popUp.SetActive(true);
                attackMenu.SetActive(false);
            }
    }

    public void Attack2()
    {
        if (Random.Range(0,2) == 0)
        {
            //För DamageIndicators
            playerAttackIndicator.MissedIndicator();
            
            Debug.Log("attack failed");
            return;
        }
        var died = fishManager.spawnedFishes[0].TakeDamage(2);  
        //För DamageIndicators
        playerAttackIndicator.AttackIndicator(2);
        
        if (!died)
        {
            int damage = fishManager.spawnedFishes[0].Attack();
            PlayerStatManager.Health -= damage;
            Debug.Log("took "+damage+" damage");
            
            //för DamageIndicators
            enemyDamageIndicator.AttackIndicator(damage);
            
            if (PlayerStatManager.Health <= 0)
            {
                PlayerStatManager.Reset();
                SceneManager.LoadScene("GameOverScene");
                Debug.Log("player died");
                return;
            }
        }
        else
        {
            PlayerStatManager.FishesCaught++;
            popUp.SetActive(true);
            attackMenu.SetActive(false);
        }
    }

    public void Continue()
    {
        if (PlayerStatManager.CatchFish())
        {
            if (PlayerStatManager.CurrentDay == PlayerStatManager.DayCount)
            {
                        
            }
            else
            {
                Debug.Log("NightScene");
                SceneManager.LoadScene("NightScene");
                return;
            }
        }
        Debug.Log(PlayerStatManager.FishesCaught+" fishes caught");
        fishManager.spawnedFishes.Remove(fishManager.spawnedFishes[0]);
        SceneManager.LoadScene("FishingScene");
        Debug.Log("Fish died");
        
    }
}
