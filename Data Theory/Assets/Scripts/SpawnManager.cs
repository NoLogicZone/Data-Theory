using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> enemies;
    [SerializeField] public int enemyCount = 0;
    [SerializeField] public int waveCount = 0;
     public int f_waveCount
    {
        get { return waveCount; }
        set
        {
            if (waveCount < 0)
            {
                waveCount = 1;
            }
            else
            {
                waveCount = value;
            }
        }
    }
    [SerializeField] GameObject player;
    [SerializeField] TextMeshProUGUI waveCountText;
    [SerializeField] TextMeshProUGUI enemiesLeftText;
    [SerializeField] PlayerController playerControllerScript;
    [SerializeField] float posX;
    [SerializeField] float posZ;
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        playerControllerScript = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.isGameOn)
        {
            SpawnEnemies();
            enemiesLeftText.SetText("Enemies left " + enemyCount);
        }
    }

    void SpawnEnemies()
    {
        if(enemyCount == 0)
        {
            waveCount++;
            waveCountText.SetText("Wave " + waveCount);
            enemyCount = waveCount * 3;
            for(int i = 0; i < enemyCount; i++)
            {
                Instantiate(enemies[Random.Range(0, 3)], new Vector3(RandomPosX(), 1, RandomPosZ()), transform.rotation);
            }
        }
    }
    float RandomPosX()
    {
        do
        {
            posX = Random.Range(player.transform.position.x - 50, player.transform.position.x + 51);
        } while (posX <= player.transform.position.x + 10 && posX >= player.transform.position.x - 10);
        return posX;
    }
    float RandomPosZ()
    {
        do
        {
            posZ = Random.Range(player.transform.position.z - 50, player.transform.position.z + 51);
        } while (posZ <= player.transform.position.z + 10 && posZ >= player.transform.position.z - 10);
        return posZ;
    }
}
