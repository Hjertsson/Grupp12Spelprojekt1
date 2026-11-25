using System.Collections;
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
    [SerializeField]
    Animator animator;

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
                animator.SetBool("isFishing",false);
                animator.SetBool("isReeling",false);
                catchTime = 3;
                return;
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
        animator.SetTrigger("bite");
        animator.SetBool("isReeling",true);
        Debug.Log("minigame start");
        minigameTimer = 2;
        minigameActive = true;
    }

    IEnumerator changeScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("CombatScene");
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("PRESSED");
            if (minigameActive && minigameTimer > 0)
            {
                animator.SetTrigger("caught");
                StartCoroutine(changeScene());
            }
            if (!fishing)
            {
                fishing = true;
                animator.SetBool("isFishing",true);
            }
        }
    }
}
