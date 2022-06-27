using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimerScript : MonoBehaviour
{
    public float timer = 2f; 
   
   public void SelfDestruct()
   {
       Destroy(gameObject,timer);
   }
}
