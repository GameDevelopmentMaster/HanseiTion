using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    public AudioSource targetMusic;
    StreamWriter writer;
    bool isStart;
    // Start is called before the first frame update
    void Start()
    {
        writer = new StreamWriter(Application.dataPath + ".txt");
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (targetMusic.isPlaying)
        {
            if (!isStart)
                isStart = true;
            if (Input.GetKeyDown(KeyCode.D))
            {
                writer.WriteLine("0:" + targetMusic.time);
                Debug.Log("Create NormalNote");
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                writer.WriteLine("1:" + targetMusic.time);
                Debug.Log("Start LongNote");
            }
            if (Input.GetKeyUp(KeyCode.J))
            {
                writer.WriteLine("2:" + targetMusic.time);
                Debug.Log("End LongNote");
            }
        }
        if (!targetMusic.isPlaying && isStart)
        {
            writer.Close();
            Debug.Log("End");
        }
    }
}
