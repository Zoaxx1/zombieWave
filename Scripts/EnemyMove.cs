using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    //Speed's enemy
    [SerializeField] private float speed;
    //Rotation Speed Enemy
    [SerializeField] private float speedRotation;
    //Force to impulse back
    [SerializeField] private float impulseToBack;
    //Damage he make to the player
    [SerializeField] private int damage;
    //Health of the enemy
    [SerializeField] private float healthEnemy;

    //Rigidbody
    private Rigidbody enemyRb;
    //The Player
    private GameObject player;
    //Player Script
    private PlayerController playerScript;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate the health 
        healthEnemy = 2;

        enemyRb = GetComponent<Rigidbody>();

        //Find the Game Object and the Script
        player = GameObject.Find("Player");
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        TargetThePlayer();
        DestroyEnemy();        
    }

    //If the bullets impact with the enemy your life down
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);

            healthEnemy--; 
        }

        if (other.gameObject.CompareTag("Granade"))
        {
            healthEnemy -= 3;
        }
    }

    //If the enemy collision with the player mkaing a impulse to back to don't get stuck with him
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerScript.LifePlayer(damage);
            Vector3 outForThePlayer = ((transform.position - player.transform.position).normalized);

            enemyRb.AddForce(outForThePlayer * impulseToBack, ForceMode.Impulse);
        }
    }

    //Move the enemy to the position's player
    void TargetThePlayer()
    {
        Quaternion lookPlayer = Quaternion.LookRotation(player.transform.position - this.transform.position);

        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, lookPlayer, speedRotation * Time.deltaTime);

        Vector3 goForThePlayer = ((player.transform.position - transform.position).normalized);

        enemyRb.AddForce(goForThePlayer * speed);

        if(player == null)
        {
            transform.position = transform.position;
        }
    }

    //If the health's enemy down to 0, destroy him
    void DestroyEnemy()
    {
        if (healthEnemy <= 0 || transform.position.y < -8)
        {
            playerScript.spawnEnemy = false;
            Destroy(gameObject);
        }
    }

}
