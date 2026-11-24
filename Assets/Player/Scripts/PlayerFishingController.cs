using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerFishingController : MonoBehaviour
{
    bool fishing = false;
    bool minigameActive = false;
    float minigameTimer;
    [SerializeField]
    float catchTime = 3f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (minigameTimer > 0)
        {
            minigameTimer -= Time.deltaTime;
            if (minigameTimer < 0)
            {
                fishing = false;
                minigameActive = false;
                catchTime = 3;
            }
        }
        if (fishing)
        {
            catchTime-=Time.deltaTime;
        }
        if (catchTime <= 0 && !minigameActive)
        {
            StartMinigame();
        }
    }

    public void StartMinigame()
    {
        Debug.Log("minigame start");
        minigameTimer = 2;
        minigameActive = true;
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("PRESSED");
            if (minigameActive && minigameTimer > 0)
            {
                SceneManager.LoadScene("CombatScene");
            }
            if (!fishing)
            {
                fishing = true;
            }
        }
    }
}
