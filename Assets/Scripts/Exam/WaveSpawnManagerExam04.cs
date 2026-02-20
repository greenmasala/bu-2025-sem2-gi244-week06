using UnityEngine;

public class WaveSpawnManagerExam04 : MonoBehaviour
{
    public Wave[] waveConfigurations;
    public WaveController waveController;

    public bool enableWaveCycling;

    private int currentWave = 0;
    private float waveEndTime = 0f;

    void Start()
    {
        waveController.StartWave(waveConfigurations[currentWave]);
    }

    void Update()
    {
        if (enableWaveCycling)
        {
            Debug.Log("starting new wave" + waveEndTime);
            currentWave = 0;
            waveEndTime = 0f;
            enableWaveCycling = false;
        }

        if (Time.time >= waveEndTime && waveController.IsComplete())
        {
            currentWave++;
            if (currentWave >= waveConfigurations.Length)
            {
                Debug.Log("All waves completed!");
                enableWaveCycling = true;
            }
            else
            {
                Debug.Log("current wave: " + currentWave);
                waveController.StartWave(waveConfigurations[currentWave]);
                waveEndTime = Time.time + waveConfigurations[currentWave].waveInterval;
                Debug.Log(waveEndTime);
            }
        }
    }
}