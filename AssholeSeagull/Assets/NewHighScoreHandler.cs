using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewHighScoreHandler : MonoBehaviour
{
    [SerializeField] GameObject newRecordObject;
    [SerializeField] AudioSource celebrationSoundPlayer;
    [SerializeField] AudioClip celebrationSound;
    [SerializeField] GameObject CelebrationCanvasObject;

    public void NewHighScoreCelebration()
    {
        newRecordObject.SetActive(true);
        CelebrationCanvasObject.SetActive(true);

        // play some confetti effects

        celebrationSoundPlayer.clip = celebrationSound;
        celebrationSoundPlayer.Play();
    }
}
