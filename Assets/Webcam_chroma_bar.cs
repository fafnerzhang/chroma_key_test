using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Webcam_chroma_bar : MonoBehaviour {
    public Material chroma_key;
    public Material key_color;
    public float D_chroma;
    public Shader chroma_shader;
    // Use this for initialization
    void Start () {
        chroma_key.SetFloat("_DChroma", D_chroma);
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
    public void Luma_tolerance(float value)
    {
        chroma_key.SetFloat("DLumaT", value);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
