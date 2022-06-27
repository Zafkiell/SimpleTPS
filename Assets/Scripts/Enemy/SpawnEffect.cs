using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(.1f,1,.1f);
        
    }
    private void Update() {
        StartCoroutine(Grow());
    }

    IEnumerator Grow()
    {
        if(transform.localScale.x < 1)
        {
            transform.localScale += new Vector3(.01f,0,.01f);
        }
        yield return new WaitForSeconds(.5f);
    }
}
