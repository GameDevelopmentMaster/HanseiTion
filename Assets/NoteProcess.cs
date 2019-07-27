using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NoteProcess : MonoBehaviour
{
    public KeyCode processKey;
    GameObject target;
    public AudioSource sfx;
    Animator ani;
    public GameObject popup;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D[] hit2D = Physics2D.RaycastAll(transform.position, Vector2.right,2);
        for(int i=0; i<hit2D.Length; i++)
        {
            if (hit2D[i] && hit2D[i].transform.tag == "Note")
            {
                Debug.DrawRay(transform.position, Vector3.right * 100);
                target = hit2D[i].transform.gameObject;
                break;
            }
        } 
       
        if (Input.GetKeyDown(processKey))
        {
            ani.SetTrigger("Input");
            sfx.Play();
            if (target != null)
            {
                GameObject.Find("NoteManager").GetComponent<NoteManager>().Combo++;
                target.GetComponent<Note>().ProcessNote();
                target = null;
            }
            else
            {
                Instantiate(popup).GetComponent<PopUp>().SetUp(0, new Vector2(-3.75f, transform.position.y) );
                GameObject.Find("NoteManager").GetComponent<NoteManager>().Combo = 0;
            }
            
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //if (collision.tag == "Note")
        //{
        //    if (target == null)
        //    {
        //        target = collision.gameObject;
        //    }
        //}
    }

   
}
