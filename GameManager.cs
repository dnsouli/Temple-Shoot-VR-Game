using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    private int score;

    [SerializeField]
    private TextMeshPro[] screenTexts;
    [SerializeField]
    private TextMeshPro[] infoTexts;
    [SerializeField]
    private TextMeshPro[] attackTimeTexts;
    [SerializeField]
    private Text[] platformTexts;
    [SerializeField]
    private string[] platformOrder;
    [SerializeField]
    private Text shootTimerText;
    private int curPlatform;

    [SerializeField]
    private float plaftormTimer = 30;
    private float curPlatformTimer;
    private bool isInsidePlatform;
    private PlatformAction platformAction;

    public string CurPlatform { get { return platformOrder[curPlatform];}}
    public static GameManager Instance {private set; get;}

    void Awake()
    {
      if(Instance != null)
      {
        Destroy(gameObject);
      }
      else
      {
        Instance = this;
      }
    }

    // Start is called before the first frame update
    void Start()
    {


      foreach(var platformText in platformTexts)
      {
        platformText.gameObject.SetActive(false);
      }

      platformTexts[curPlatform].gameObject.SetActive(true);
      shootTimerText.gameObject.SetActive(false);
        foreach (var tm in infoTexts)
        {
            tm.text = platformTexts[curPlatform].GetComponent<Text>().text;
        }
    }

    void Update()
    {
      if(isInsidePlatform)
      {
        curPlatformTimer += Time.deltaTime;
        if(curPlatformTimer >= plaftormTimer)
        {
          NextPlatform();
        }

        shootTimerText.text = "Attack Time: " + Mathf.Ceil(plaftormTimer - curPlatformTimer);
            attackTimeTexts[curPlatform].text = shootTimerText.text;
        }
    }

    public void AddScore(int points)
    {
      score = Mathf.Max(score + points, 0);
      scoreText.text = "Score: " + score;
      foreach(var tm in screenTexts)
        {
            tm.text = "Score: " + score;
        }
    }

    public void NextPlatform()
    {
      platformAction.SetActivePlatformObjects(false);
      isInsidePlatform = false;
      curPlatform++;

        if (curPlatform >= 4)
        {
            PlayerPrefs.SetInt("Score", score);
            PlayerPrefs.Save();
            SceneManager.LoadScene("EndScreen");
        }
        else
        {
            platformTexts[curPlatform].gameObject.SetActive(true);
            shootTimerText.gameObject.SetActive(false);
            foreach (var tm in infoTexts)
            {
                tm.text = platformTexts[curPlatform].GetComponent<Text>().text;
            }
        }
    }

    public void EnterPlatform(PlatformAction action)
    {
      platformAction = action;
      isInsidePlatform = true;
      curPlatformTimer = 0;
      platformAction.SetActivePlatformObjects(true);
      platformTexts[curPlatform].gameObject.SetActive(false);
      shootTimerText.gameObject.SetActive(true);
    }
}
