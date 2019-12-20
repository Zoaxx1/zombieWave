using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GranadeThrow : MonoBehaviour
{
    [SerializeField] private float forceThrow; 
    private Rigidbody granadeRb;
    private SphereCollider granadeCollider;

    private GameObject shootPoint;

    // Start is called before the first frame update
    void Start()
    {
        granadeRb = GetComponent<Rigidbody>();
        granadeCollider = GetComponent<SphereCollider>();

        shootPoint = GameObject.Find("PointShooter");
    }

    // Update is called once per frame
    void Update()
    {
        granadeRb.velocity = transform.TransformDirection(Vector3.forward * forceThrow);

        StartCoroutine(Explosion());
    }

    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(4);

        granadeCollider.radius = 5.0f;

        Destroy(gameObject, 0.5f);
    }
}
