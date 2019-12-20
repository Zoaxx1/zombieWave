using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    //Player Move and Run
    [SerializeField] private float speed;
    [SerializeField] private float speedRotation;
    [SerializeField] private float speedOfRotation;
    [SerializeField] private float life;
    private bool canRun = true;
    private Rigidbody playerRb;

    private GameObject enemyPosition;
    public bool spawnEnemy = false;

    private PointToShoot point;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        life = 100;

        enemyPosition = GameObject.Find("Enemy 1(Clone)");

        point = GameObject.Find("PointShooter").GetComponent<PointToShoot>();
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerTarget();
        if (!point.pause)
        {
            RotationPlayer();
            PlayerMoving();
        }
    }

    void PlayerMoving()
    {
        float moveHorizontal = CrossPlatformInputManager.GetAxis("Horizontal") * speed;
        float moveVertical = CrossPlatformInputManager.GetAxis("Vertical") * speed;

        transform.Translate(moveHorizontal, 0, moveVertical);
        
    }

    /*void PlayerTarget()
    {
        if (enemyPosition != null && spawnEnemy)
        {
            Quaternion enemyTarget = Quaternion.LookRotation(enemyPosition.transform.position - this.transform.position);

            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, enemyTarget, speedRotation * Time.deltaTime);
        }
        else if (spawnEnemy) 
        {
            enemyPosition = GameObject.Find("Enemy(Clone)");
        }

    }*/

    public void RotationPlayer()
    {
        float mouseX = CrossPlatformInputManager.GetAxis("Mouse X");

        transform.Rotate(Vector3.up * speedOfRotation * mouseX * Time.deltaTime);
    }
    
    public void LifePlayer(int healthless)
    {
        life -= healthless;
        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }
}


