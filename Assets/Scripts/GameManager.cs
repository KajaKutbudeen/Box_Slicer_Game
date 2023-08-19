using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] Targets;
   // [SerializeField]
    float SpawnRate = 3;
    public Text scoretext;
    [SerializeField]
    int Realscore;
    bool Gameover = false;
    public GameObject GameOverText;
    public GameObject Restart;
    [SerializeField]
    int diffculty;
    public GameObject Title;
    public GameObject Easy;
    public GameObject Medium;
    public GameObject Hard;

    private void Start()
    {
    //   StartCoroutine(SpawnTarget());

    }
   public void UpdateScore(int  score)
    {
        Realscore += score;
        scoretext.text = "Score: " + Realscore.ToString();
        if(Realscore <=0)
        {
            Realscore = 0;
            scoretext.text = "Score: " + Realscore.ToString();
            GameOver();
        }
    }
    void GameOver()
    {
        Gameover = true;
        GameOverText.SetActive(true);
        Restart.SetActive(true);
    }
    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
    public void difficulty(int value)
    {
        Title.SetActive(false);
        Easy.SetActive(false);
        Medium.SetActive(false);
        Hard.SetActive(false);
        diffculty = value;
        StartCoroutine(SpawnTarget());
    }
    IEnumerator SpawnTarget()
    {
        SpawnRate /= diffculty;
        while (!Gameover)
        {           
            int index = Random.Range(0, Targets.Length);
            Instantiate(Targets[index]);
            yield return new WaitForSeconds(SpawnRate);
        }
    }
}
