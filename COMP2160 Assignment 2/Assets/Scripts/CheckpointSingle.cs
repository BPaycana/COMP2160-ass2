using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class CheckpointSingle : MonoBehaviour
{
    private TrackCheckpoints trackCheckpoints;
    private CarHealth car;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            trackCheckpoints.PlayerThroughCheckpoint(this);

            car = other.gameObject.GetComponent<CarHealth>();

            Debug.Log("Time: " + Timer.instance.timerCount.text + " Health: " + car.currentHealth);
            AnalyticsResult analyticsResult = Analytics.CustomEvent("Time: " + Timer.instance.timerCount.text + " Health: " + car.currentHealth);

            if (car.currentHealth <= 80)
            {
                car.TakeDamage(-20);
            }

            if (car.currentHealth > 80 && car.currentHealth < 100)
            {
                car.currentHealth = 100;
            }
        
        }
    }

    public void SetTrackCheckpoints(TrackCheckpoints trackCheckpoints)
    {
        this.trackCheckpoints = trackCheckpoints;
    }
}
