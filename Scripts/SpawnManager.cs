using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    //Enemy Prefab
    public GameObject enemyPrefab;

    //Number of Enemys Spawn
    [SerializeField]private int waveNumber = 5;
    private int enemyCount;

    private int waveCount;
    private int countToSpawn;
    private bool timePass = false;

    public Text numberWave;
    public Text countBack;

    // Start is called before the first frame update
    void Start()
    {
        countToSpawn = 3;
        waveCount = 1;
        waveNumber = 1;
        //Call the function Spawn
        SpawnEnemysWaves(waveNumber);

        countBack.text = "";
        numberWave.text = "WAVE " + waveCount;
    }

    // Update is called once per frame
    void Update()
    {
        //Quantity of enemys spawn on that wave
        enemyCount = FindObjectsOfType<EnemyMove>().Length;

        //If enemyCount <= 0 plus the wave and call the function spawn
        if(enemyCount <= 0)
        {
            
            StartCoroutine(TimeToSpawn());
            if (timePass)
            {
                waveCount++;
                numberWave.text = "WAVE " + waveCount;
                waveNumber += waveNumber;
                SpawnEnemysWaves(waveNumber);
                timePass = !timePass;
            }
        }
    }

    IEnumerator TimeToSpawn()
    {
        yield return new WaitForSeconds(7);
        countBack.text = "" + Time.time;
        timePass = !timePass;
    }

    //Spawn Enemy Waves
    void SpawnEnemysWaves(int numberOfEnemys)
    {
        for (int i = 0; i< numberOfEnemys; i++)
        {
            Instantiate(enemyPrefab, GeneratorRandomPosition(), enemyPrefab.transform.rotation);
        }        
    }

    //Generator of Random Position to the Enemys
    public Vector3 GeneratorRandomPosition()
    {
        float randomX = Random.Range(-11, 11);
        float randomZ = Random.Range(-15, 10);

        Vector3 spawnRandomLocation = new Vector3(randomX, 4, randomZ);

        return spawnRandomLocation;
    }
}
