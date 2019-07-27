using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float speed;
    public static int noteCount;
    public GameObject noteEnd;
    public GameObject popUp;
    public ParticleSystem Efter;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0,0);
        if (transform.position.x <= -5.4)
        {
            Instantiate(popUp).GetComponent<PopUp>().SetUp(0, new Vector2(-3.75f, transform.position.y));
            Destroy(gameObject);
        }
    }
    public void ProcessNote()
    {
        float d = transform.position.x - (-5);
        if (d > 0.4f)
        {
            Instantiate(popUp).GetComponent<PopUp>().SetUp(1, new Vector2(-3.75f, transform.position.y));
        }
        else
        {
            Instantiate(popUp).GetComponent<PopUp>().SetUp(2, new Vector2(-3.75f, transform.position.y));
        }
        Instantiate(Efter).transform.position = transform.position;
        GameObject noteEndObject = Instantiate(noteEnd);
        noteEndObject.transform.position = transform.position;
        CountManager.instance.ProCessNote++;
        Destroy(gameObject);
    }

    public void MissPopUp()
    {
        Instantiate(popUp).GetComponent<PopUp>().SetUp(0, new Vector2(-3.75f, transform.position.y));
    }
}
