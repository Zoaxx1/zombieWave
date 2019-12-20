using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointToShoot : MonoBehaviour
{
    //Bullet to shoot
    public GameObject[] armsPrefab;

    //Player Arm for he shoot
    private GameObject armPosition;
    //Player
    private GameObject player;

    [SerializeField] private bool autoShoot = false;

    public bool pause = false;

    // Start is called before the first frame update
    void Start()
    {
        //Position of the Game Objects
        armPosition = GameObject.Find("Pistol");
        player = GameObject.Find("Player");        
    }

    //If pushdown the red button call the function ShootBullet to do that
    public void ShootBullet()
    {
        if (!autoShoot && !pause)
        {
            Instantiate(armsPrefab[0], armPosition.transform.position, player.transform.rotation);
        }             
    }

    public void ThrowGranades()
    {
        if (!pause)
        {
            Instantiate(armsPrefab[1], armPosition.transform.position, player.transform.rotation);
        }       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && autoShoot)
        {
            Instantiate(armsPrefab[0], armPosition.transform.position, player.transform.rotation);
        }
    }

    public void AutoShootONOFF()
    {
        autoShoot = !autoShoot;
    }
    
    public void Pause()
    {
        pause = !pause;

        Time.timeScale = (pause) ? 0 : 1f;
    }
}
