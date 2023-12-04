using Pathfinding;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator enemyAnimator;
    private AILerp aiLerp;

    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        aiLerp = GetComponent<AILerp>();
    }

    void Update()
    {
        Vector2 movementDirection = GetMovementDirection();

        if (aiLerp != null)
        {
            if (Mathf.Abs(movementDirection.x) > Mathf.Abs(movementDirection.y))
            {
                // Horizontal
                enemyAnimator.SetFloat("X", movementDirection.x);
                enemyAnimator.SetFloat("Y", 0f);
            }
            else
            {
                // Vertical
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
            return new Vector2(aiVelocity.x, aiVelocity.z).normalized;
        }
        else
        {
            return Vector2.zero;
        }
    }
}
