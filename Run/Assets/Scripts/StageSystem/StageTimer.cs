using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StageTimer : MonoBehaviour
{
    [SerializeField] float LevelTimer;
    [SerializeField] TextMeshProUGUI Countdown;

    private float TimeDecay = 1;
    [SerializeField] Animator TransitionController;
    
    private const string End = "End";

    void Update()
    {
        LevelTimer = Mathf.MoveTowards(LevelTimer, 0, TimeDecay * Time.deltaTime);

        Countdown.text = LevelTimer.ToString("N0");

        if (LevelTimer <= 0)
        {
            StartCoroutine(LoadLevel());
        }
    }

    private IEnumerator LoadLevel()
    {
        TransitionController.SetTrigger(End);

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
