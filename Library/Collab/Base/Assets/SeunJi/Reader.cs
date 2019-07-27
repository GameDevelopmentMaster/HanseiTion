using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Reader : MonoBehaviour
{
    public TextAsset recordFile;
    public GameObject note;
    public float noteSpeed;
    int sw = 1;
    float prevSens;
    bool isCoolTime = false;
    bool isChanged;
    int idx;
    int prevIdx;
    int fram;
    // Start is called before the first frame update
    void Awake()
    {
        note.GetComponent<Note>().speed = noteSpeed;
        ReadAllLine();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void ReadAllLine()
    {
        string[] str = recordFile.text.Split('\n');
        for (int i = 0; i < str.Length; i++)
        {
            ProcessLine(str[i]);
        }
        GetComponent<AudioSource>().Play();


    }
    void ProcessLine(string _line)
    {
        string[] line = _line.Split(':');
        if (float.Parse(line[1]) > prevSens + 1.5)
        {
            GameObject _note = Instantiate(note);
            if (isCoolTime == false&&fram>3)
            {
                _note.transform.position = new Vector2(float.Parse(line[0]) * noteSpeed-4.85f, sw * 2); 
                isCoolTime = true;
                prevIdx = idx;
                idx = 0;
                isChanged = false;
                fram = 0;
            }
        }

        if (fram <= 3)
        {

            fram++;
        }
        else
        {
            idx++;
        }
        if (idx > prevIdx*1.2f)
        {
            if (!isChanged)
            {
                isChanged = true;
                Debug.Log("revere");
                sw *= -1;
            }
        }
        if (isCoolTime == true)
        {
            if (idx > 5)
            {
                isCoolTime = false;
                idx = 0;
            }
            else
            idx++;
        }
        prevSens = float.Parse(line[1]);
    }
}
