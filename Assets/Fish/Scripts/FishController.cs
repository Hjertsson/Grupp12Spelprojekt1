using Unity.Mathematics;
using UnityEngine;

public class FishController : MonoBehaviour
{
    [SerializeField]
    private int health = 10;

    public bool TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(this);
            return true;
        } 
        return false;
    }

    public int Attack()
    {
        return 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
