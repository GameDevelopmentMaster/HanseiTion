using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reader : MonoBehaviour
{
    public TextAsset recordFile;
    public GameObject note;
    public float noteSpeed;
    private int sw = 1;
    private float prevSens;
    private bool isCoolTime = false;
    private bool isChanged;
    private int idx;
    private int prevIdx;
    private int fram;

    // Start is called before the first frame update
    private void Awake()
    {
        note.GetComponent<Note>().speed = noteSpeed;
        ReadAllLine();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void ReadAllLine()
    {
        string[] str = recordFile.text.Split('\n');
        for (int i = 0; i < str.Length; i++)
        {
            ProcessLine(str[i]);
        }
        GetComponent<AudioSource>().Play();
    }

    private void ProcessLine(string _line)
    {
        string[] line = _line.Split(':');
        if (float.Parse(line[1]) > prevSens + 1.5)
        {
            if (isCoolTime == false && fram > 3)
            {
                GameObject _note = Instantiate(note);
                _note.transform.position = new Vector2(float.Parse(line[0]) * noteSpeed - 4.85f, sw * 2 - 1.5f);
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
        if (idx > prevIdx * 1.2f)
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