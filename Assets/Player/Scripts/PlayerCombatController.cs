using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerCombatController : MonoBehaviour
{
    [SerializeField]
    FishManager fishManager;

    [SerializeField] private GameObject popUp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed){
        var died = fishManager.spawnedFishes[0].TakeDamage(1);
            if (!died)
            {
                int damage = fishManager.spawnedFishes[0].Attack();
                PlayerStatManager.Health -= damage;
                Debug.Log("took "+damage+" damage");
                if (PlayerStatManager.Health <= 0)
                {
                    Debug.Log("player died");
                }
            }
            else
            {
                popUp.SetActive(true);
            }
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
