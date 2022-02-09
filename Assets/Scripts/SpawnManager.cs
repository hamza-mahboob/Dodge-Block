using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    GameObject[] obstacles = new GameObject[5];
    GameManager gameManager = new GameManager();
    public GameObject bonus;
    float startDelay = 1f;
    float intervalDelay = 5f;
    int randomIndex;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("WaveSpawner", startDelay, intervalDelay);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }

    void WaveSpawner()
    {
        if (gameManager.isGamePlaying())
        {
            Debug.Log("Wave Spawner");
            //random index
            randomIndex = Random.Range(0, obstaclePrefab.Length);

            //loop to instantiate all obstacles
            for (int i = 0; i < obstaclePrefab.Length; i++)
            {
                obstacles[i] = Instantiate(obstaclePrefab[i]);
                //disable a random obstacle from array
                if (i == randomIndex)
                {
                    //spawn bonus instead of empty space after every 5s
                    if(time > 5)
                    {
                        time = 0;
                        Instantiate(bonus, new Vector3(obstacles[i].transform.position.x, obstacles[i].transform.position.y, obstacles[i].transform.position.z), obstacles[i].transform.rotation);
                    }
                    obstacles[i].SetActive(false);
                }
            }
        }
    }
}
