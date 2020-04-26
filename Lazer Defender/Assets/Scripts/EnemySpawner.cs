using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] List<WaveConfig> waveConfig;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = true;
    float testFiringPeriodSpeed = 0.2f;
    
    //Cached Reference
    Player thePlayer;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        // Continue looping the waves if the looping is set to true
        do
        {
            yield return StartCoroutine(SpawnAllWaves());

            thePlayer = FindObjectOfType<Player>();

            // If speed reached zero, keep it at 0.2
            if(thePlayer.GetFiringPeriod() - testFiringPeriodSpeed  <= 0)
            {
                thePlayer.SetFiringPeriodMin();
            }
            else
            {
                // If the speed isn't zero, keep going faster
                thePlayer.IncreasePlayerShootingSpeed();
            }
        } 
        while (looping);
    }

    private IEnumerator SpawnAllWaves()
    {
        for(int waveIndex = startingWave; waveIndex < waveConfig.Count; waveIndex ++)
        {
            var currentWave = waveConfig[waveIndex];
            yield return new WaitForSeconds(2);
            StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {   
        for(int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount ++)
        {
            var newEnemy = Instantiate(
                waveConfig.GetEnemyPrefab(),
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.identity);
        
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);

            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }
}
