using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveEffectScript : MonoBehaviour
{
    Material mat;
    public float dissolve = -0.10f;
    public bool startDissolve = false;
    // Start is called before the first frame update
    void Start()
    {
        //mat = Instantiate<Material>(GetComponent<Renderer>().material);
        mat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if(startDissolve)
        {
            dissolve += Time.deltaTime * 0.6f;
        }
        mat.SetFloat("_DissolveEffect",dissolve);
    }
}
