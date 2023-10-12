using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float groundCheckDistance = .6f;
    [SerializeField] private LayerMask whatIsGround; 
    private bool movingRight = true; 

    [Header("Combat Settings")]
    [SerializeField] private int maxHealth = 5;
    private int currentHealth;
    [SerializeField] private int damage = 1; 

    private Rigidbody2D enemyRigidBody; 
    private EnemySpawner spawner;  

    // Start is called before the first frame update
    void Awake()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    public void Initialize(EnemySpawner spawnerReference)
    {
       spawner = spawnerReference;
  }

    // Update is called once per frame
    void Update()
    {
        Move();  
    }
    void Move(){
        Vector2 groundCheckPosition = movingRight ?
            new Vector2(transform.position.x + 0.5f, transform.position.y):
            new Vector2(transform.position.x - 0.5f, transform.position.y);

            bool isGrounded = Physics2D.Raycast(groundCheckPosition, Vector2.down, groundCheckDistance, whatIsGround);

            if(!isGrounded)
            {
                movingRight =!movingRight;
            }

            enemyRigidBody.velocity = movingRight ?
            new Vector2(moveSpeed, enemyRigidBody.velocity.y):
            new Vector2(-moveSpeed, enemyRigidBody.velocity.y);
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; 
        if (currentHealth <=0)
        {
            Die();
        }
    }
    public void Die()
    {
        if(spawner !=null)
        {
            spawner.EnemyDied();
        }
        Destroy(gameObject);
    }
private void OnCollisionEnter2D(Collision2D other) {
AdvancedPlayerMovement player = other.gameObject.GetComponent<AdvancedPlayerMovement>();
if(player != null)
{
    Debug.Log($"Player took {damage} from enemy");
}    
}
}
