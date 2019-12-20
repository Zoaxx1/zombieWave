using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private Rigidbody bulletRb;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        bulletRb.AddRelativeForce(Vector3.left * speed, ForceMode.Impulse);

        DestroyBullet();
    }

    void DestroyBullet()
    {
        if(transform.position.z > 20 || transform.position.z < -20 
            || transform.position.x > 20 || transform.position.x < -20)
        {
            Destroy(gameObject);
        }
    }
}
