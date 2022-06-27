using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsScript : MonoBehaviour
{
    public int pontos1, pontos2;
    public Text score1, score2;
    
    public void AddScore()
    {
        score1.text = pontos1.ToString();
        score2.text = pontos2.ToString();
    }
}
