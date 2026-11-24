using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombatController : MonoBehaviour
{
    [SerializeField]
    private int health = 10;
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
                health -= damage;
                Debug.Log("took "+damage+" damage");
                if (health <= 0)
                {
                    Debug.Log("player died");
                }
            }
            else
            {
                fishManager.spawnedFishes.Remove(fishManager.spawnedFishes[0]);
            Debug.Log("Fish died");
            }
        }
    }
}
