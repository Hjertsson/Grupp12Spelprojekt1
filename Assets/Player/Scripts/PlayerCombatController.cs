using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerCombatController : MonoBehaviour
{
    [SerializeField]
    FishManager fishManager;

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
                PlayerStatManager.health -= damage;
                Debug.Log("took "+damage+" damage");
                if (PlayerStatManager.health <= 0)
                {
                    Debug.Log("player died");
                }
            }
            else
            {
                PlayerStatManager.FishesCaught++;
                Debug.Log(PlayerStatManager.FishesCaught+" fishes caught");
                fishManager.spawnedFishes.Remove(fishManager.spawnedFishes[0]);
                SceneManager.LoadScene("FishingScene");
            Debug.Log("Fish died");
            }
        }
    }
}
