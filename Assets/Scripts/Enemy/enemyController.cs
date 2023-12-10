using Pathfinding;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField]
    float damage = 10.0F;

    private Animator enemyAnimator;
    private AILerp aiLerp;

    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        aiLerp = GetComponent<AILerp>();
  
    }

    void FixedUpdate()
    {
        Vector2 movementDirection = GetMovementDirection();
        Debug.Log("Movement Direction: " + movementDirection);
        if (aiLerp != null)
        {
            if (Mathf.Abs(movementDirection.x) > Mathf.Abs(movementDirection.y))
            {
                // Horizontal
                Debug.Log("Horizontal Movement");
                enemyAnimator.SetFloat("X", movementDirection.x);
                enemyAnimator.SetFloat("Y", 0f);
            }
            else
            {
                // Vertical
                Debug.Log("Vertical Movement");
                Debug.Log("X: " + movementDirection.x + ", Y: " + movementDirection.y);
                enemyAnimator.SetFloat("X", 0f);
                enemyAnimator.SetFloat("Y", movementDirection.y);
            }
        }
        else
        {
            Debug.LogError("AILerp component not found or not initialized.");
        }
    }


    Vector2 GetMovementDirection()
    {
        if (aiLerp != null)
        {
            Vector3 aiVelocity = aiLerp.velocity;

            // Utiliza aiVelocity.x y aiVelocity.y en lugar de aiVelocity.x y aiVelocity.z
            return new Vector2(aiVelocity.x, aiVelocity.y).normalized;
        }
        else
        {
            return Vector2.zero;
        }
    }

     void OnCollisionEnter2D(Collision2D other) //Bulllet damage/Player damage
    {
        if (other.gameObject.tag == "Bullet")
        {

            GameManagerController gameManager = FindFirstObjectByType<GameManagerController>();
            gameManager.IncrementKillCount();

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
       

        if (other.collider.CompareTag("Player"))
        {
            Vector2 contactPoint = other.GetContact(0).normal;
            
                HealthController controller =
                other.collider.GetComponent<HealthController>();
                controller.TakeDamage(damage);
            

        }


    }

}
