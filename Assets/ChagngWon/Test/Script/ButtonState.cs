using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonState : MonoBehaviour
{
    Color a;
    // Start is called before the first frame update
    void Start()
    {

        a = transform.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        switch (transform.name) {

            case "NextPage":
                if (GameObject.Find("UIManager").GetComponent<SpriteChangeSystem>().GetStage() > 1)
                {
                    transform.GetComponent<Image>().color = new Color(a.a, a.g, a.b, 0.5f);
                }
                else
                {
                    transform.GetComponent<Image>().color = new Color(a.a, a.g, a.b, 1f);
                }
                break;
            case "PrePage":
                if (GameObject.Find("UIManager").GetComponent<SpriteChangeSystem>().GetStage() < 1)
                {
                    transform.GetComponent<Image>().color = new Color(a.a, a.g, a.b, 0.5f);
                }
                else
                {
                    transform.GetComponent<Image>().color = new Color(a.a, a.g, a.b, 1f);
                }
                break;
        }

    }
}
