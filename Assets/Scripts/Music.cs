using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    void Update()
    {
        float[] spectrum = new float[256];
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);
        float highestBass = 0;
        for (int i = 1; i < spectrum.Length - 1; i++)
        {
            if (spectrum[i] > highestBass)
            {
                highestBass = spectrum[i];
            }
        }
        gameObject.GetComponent<Transform>().localScale = new Vector3(1 + highestBass, 1 + highestBass, 1 + highestBass);
    }
}
