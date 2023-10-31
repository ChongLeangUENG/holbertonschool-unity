using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Timer timerScript = other.GetComponent<Timer>();
            if (timerScript != null)
            {
                timerScript.enabled = true; // Enable the Timer script on the Player
                timerScript.StartTimer();   // Start the timer
            }
        }
    }
}
