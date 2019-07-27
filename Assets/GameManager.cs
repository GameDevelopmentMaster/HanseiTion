using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState
{
    Collection,Main,InGame
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool canMove = true;
    public GameState gameState;
    public GameState GameState
    {
        get { return gameState; }
        set
        {
            gameState = value;
            for(int i = 0; i < 3; i ++)
            {
                UIs[i].SetActive(false);
            }
            UIs[(int)gameState].SetActive(true);
            StartCoroutine(CameraMove());
        }
    }
    public GameObject[] UIs = new GameObject[3];
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        GameState = GameState.Main;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (canMove)
            {
                switch (GameState)
                {
                    case GameState.Main:
                        SoundManager.instance.Play();
                        GameState = GameState.Collection;
                        break;
                    case GameState.InGame:
                        GameState = GameState.Main;
                        break;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (canMove)
            {
                switch (GameState)
                {
                    case GameState.Main:
                        GameState = GameState.InGame;
                        break;
                    case GameState.Collection:
                        SoundManager.instance.Stop();
                        GameState = GameState.Main;
                        break;
                }
            }
        }
    }
    IEnumerator CameraMove()
    {
        canMove = false;
        Vector3 targetPos = new Vector3(((int)GameState-1) * -19.2f, 0,-10);
        for (int i = 0; i < 15; i++)
        {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, targetPos,0.5f);
            yield return new WaitForFixedUpdate();
        }
        Camera.main.transform.position = targetPos;
        canMove = true;
    }
}
