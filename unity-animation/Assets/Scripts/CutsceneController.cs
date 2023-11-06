using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public Animator cutsceneAnimator;
    public Camera mainCamera;
    public GameObject player;
    public GameObject timerCanvas;

    private bool animationFinished = false;

    private void Update()
    {
        // Check if the Level01 animation is finished
        if (cutsceneAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && !animationFinished)
        {
            // Enable the Main Camera
            mainCamera.enabled = true;

            // Enable the PlayerController script
            PlayerController playerController = player.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.enabled = true;
            }

            // Enable the TimerCanvas
            timerCanvas.SetActive(true);

            // Disable this CutsceneController
            gameObject.SetActive(false);

            animationFinished = true;
        }
    }
}
