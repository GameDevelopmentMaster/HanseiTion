using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Checker : MonoBehaviour
{
    public AudioSource targetMusic;
    StreamWriter writer;
    bool isStart;
    // Start is called before the first frame update
    void Start()
    {
        writer = new StreamWriter(Application.dataPath + "Checker.txt");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (targetMusic.isPlaying)
        {
            if (!isStart)
                isStart = true;
            float[] spectrumData = AudioListener.GetSpectrumData(1024, 0, FFTWindow.Hamming);
            float t = 0;
            for (int i = 0; i < spectrumData.Length; i++)
            {
                t += spectrumData[i];
            }
            writer.WriteLine(targetMusic.time + ":" + t);
        }
        if (!targetMusic.isPlaying && isStart)
        {
            writer.Close();
            Debug.Log("End");
        }
    }
}
