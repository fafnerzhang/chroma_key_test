using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chroma : MonoBehaviour {
    public Material chroma_key;
    public Material key_color;
    public float D_chroma;
    public float D_chroma_max;
    public float scroll_bar;
    
	// Use this for initialization
	void Start ()
    {
        chroma_key.SetFloat("_DChroma",D_chroma/ D_chroma_max);
	}
	public void Difference_chroma(float value)
    {
        chroma_key.SetFloat("_DChroma", value);
    }
    public void D_chroma_tolerance(float value)
    {
        chroma_key.SetFloat("_DChromaT", value);
    }
    
   public void Luma(float value)
    {
        chroma_key.SetFloat("_Luma", value);
    }
    
	// Update is called once per frame
	/*void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            D_chroma -= 5;
            chroma_key.SetFloat("_DChroma", D_chroma / D_chroma_max);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            D_chroma += 5;
            chroma_key.SetFloat("_DChroma", D_chroma / D_chroma_max);
        }*/

   // }
}
