using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [HideInInspector]
    public static int players;
    public GameObject transition;

    // Start is called before the first frame update
    void Start()
    {
      DontDestroyOnLoad(this); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(int choice)
    {
        players = choice;
        transition.SetActive(true);
       Invoke("ChangeLevel",3f);
    }
    void ChangeLevel(){
        SceneManager.LoadScene("WaveMode");
    }
}
