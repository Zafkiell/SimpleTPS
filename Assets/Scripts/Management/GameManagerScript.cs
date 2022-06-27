using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameScreen;
    public GameObject player1,player2;
    public GameObject resultScreen,text1,text2;
    public PointsScript points;
    public int finalPoint1,finalPoint2;
    public GameObject[] Transition;
    public GameObject TransitionCanvas;
    
    //Tutorial properties
    public GameObject tutorialCanvas,waveSpawner;

    private void Start() {
        Invoke("StartWaves",5f);

        if(MenuScript.players == 1)
        {
            player1.SetActive(true);
            player2.SetActive(false);
        }
        else{
            player2.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(!player1.activeSelf && !player2.activeSelf)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        finalPoint1 = points.pontos1;
        finalPoint2 = points.pontos2;
    }
    public void Revive(int index)
    {
        if(index == 0)player1.SetActive(true);
        if(index == 1)player2.SetActive(true);
    }
    public void TransitionAnim()
    {
        TransitionCanvas.SetActive(true);
        Invoke("OpenAnim",1f);
    }
    void OpenAnim()
    {
        OpenResults();
        Transition[0].GetComponent<Animator>().SetTrigger("Close");
        Transition[1].GetComponent<Animator>().SetTrigger("Close");
    }
    public void OpenResults()
    {
        text1.GetComponent<TMPro.TMP_Text>().text = finalPoint1.ToString();
        text2.GetComponent<TMPro.TMP_Text>().text = finalPoint2.ToString();
        resultScreen.SetActive(true);
        gameScreen.SetActive(false);
    }
    void StartWaves()
    {
        tutorialCanvas.SetActive(false);
        waveSpawner.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
