using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SpriteChangeSystem : MonoBehaviour
{
    Text ComboText, ScoreText;
    Sprite ChangeSprite;
    public Sprite[] SpriteData;
    public Button[] CollectionSprite;
    string PreSceneName;
    int ScoreNum;
    int Combo;
    public int Stage;
    public Text[] TextList;
    int curIndex;
    // Start is called before the first frame update
    void Start()
    {
        CollectionSprite[SoundManager.instance.index].transform.GetChild(0).GetComponent<Image>().fillAmount = PlayerPrefs.GetFloat(SoundManager.instance.clips[SoundManager.instance.index].name);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public int GetStage()
    {
        return Stage;
    }
    public void GameStart()
    {
        SceneManager.LoadScene("InGame");
    }
    public void ScoreAdd(int Value)
    {
        ScoreNum += Value;
        Combo++;
        RankChangeSprite(ScoreNum / 25);
        ScoreText.text = ScoreNum.ToString();
        ComboText.text = Combo.ToString();
    }

    public void SceneNameData()
    {
        ChangeSprite = GameObject.Find("EndPos").GetComponent<Sprite>();
        ScoreText= GameObject.Find("Score").GetComponent<Text>();
        ComboText = GameObject.Find("Combo").GetComponent<Text>();
    }

    public void SceneLoadData(int Index)
    {
        SceneManager.LoadScene(Index);
        if (Index != 0)
        {
            SceneNameData();
        }
        else
        {
            CollectionSprite[Stage].GetComponent<Image>().sprite = ChangeSprite;
            ScoreNum = Combo = 0;
        }
    }

    public void StageData(int Value)
    {
        switch (Value) {
            case 1:
                if(Stage < 2)
                Stage++;
                break;
            case 2:
                if(Stage >0)
                Stage--;
                break;
        }
        
    }
    
    

    public void MainChange(GameObject Value)
    {
        switch (Value.transform.parent.name)
        {
            case "MusicSelect":

                break;

            case "Collection":

                break;
        }
    }

    public void RankChangeSprite(int Index)
    {
        ChangeSprite = SpriteData[Index+(Stage*5)];
    }
}
