using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float checkRadius;
    public float attackRadius;

    public bool shouldRotate;

    public LayerMask whatIsPlayer;

    private Transform target;
    private Rigidbody rb;
    private Animator anim;
    private Vector2 movement;
    private Vector3 dir;

    private bool isInChaseRange;
    private bool isInAttackRange;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        // Buscar el objeto del jugador solo una vez
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            target = playerObject.transform;
        }
        else
        {
            Debug.LogError("No se encontró el objeto del jugador con la etiqueta 'Player'.");
        }
    }

    private void Update()
    {
        anim.SetBool("isRunning", isInChaseRange);

        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);

        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;
        if(shouldRotate)
        {
            anim.SetFloat("X",dir.x);
            anim.SetFloat("Y", dir.y);
        }

    }
    private void FixedUpdate()
    {
        if (isInChaseRange && !isInAttackRange)
        {
            MoveCharacter(movement);
        }
        else if (isInAttackRange)
        {
            MoveCharacter(Vector2.zero);
        }
    }


    private void MoveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }
}



