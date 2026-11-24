using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombatController : MonoBehaviour
{
    [SerializeField]
    private int health = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FishManager.SpawnFish();
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    public void Attack(InputAction.CallbackContext context)
    {
        var died = FishManager.spawnedFishes[0].TakeDamage(1);
            if (!died)
            {
                int damage = FishManager.spawnedFishes[0].Attack();
                health -= damage;
                Debug.Log("took "+damage+" damage");
                if (health <= 0)
                {
                    Debug.Log("player died");
                }
            }
            else
            {
            Debug.Log("Fish died");
            }
    }
}
