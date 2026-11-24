using Unity.Mathematics;
using UnityEngine;

public class FishController : MonoBehaviour
{
    [SerializeField]
    private int health = 10;
    [SerializeField]
    private int damage = 1;

    public bool TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("FISH DESTROYED");
            return true;
        } 
        return false;
    }

    public int Attack()
    {
        return damage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
