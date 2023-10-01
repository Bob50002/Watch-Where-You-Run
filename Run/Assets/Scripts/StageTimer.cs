using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StageTimer : MonoBehaviour
{
    [SerializeField] float LevelTimer;

    private float timeDecay = 1;

    [SerializeField] Animator TransitionController;

    [SerializeField] TextMeshProUGUI Countdown;

    void Start()
    {
        //Door.GetComponent<DoorEnd>().enabled = false;
    }

    
    void Update()
    {
        LevelTimer = Mathf.MoveTowards(LevelTimer, 0, timeDecay * Time.deltaTime);

        Countdown.text = LevelTimer.ToString("N0");

        if (LevelTimer <= 0)
        {
            Debug.Log("You win");

            StartCoroutine("LoadLevel");
        }
    }

    IEnumerator LoadLevel()
    {
        TransitionController.SetTrigger("End");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
