using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager Instance { get; private set; } // static singleton
   public GameObject currentLevelObj;
    public List<GameObject> Levels;


   public float speed;
    public float money;

    // Start is called before the first frame update
   
    int level;
    void Awake()
    {
        
        Instance = this;

    }
    public void setLevelStuffs()
    {

        if (PlayerPrefs.HasKey("Level"))
        {
            level = PlayerPrefs.GetInt("Level");
            money = PlayerPrefs.GetFloat("Balance");

        }
        else
        {
            level = 1;
            money = 0;
        }


        if (level >= 3)
        {
            currentLevelObj = Levels[Random.Range(0, 2)];
        }
        else
        {
            currentLevelObj = Levels[level - 1];
        }
        UIManager.instance.lvltext.text = "LEVEL " + level.ToString();
        UIManager.instance.Balancetext.text = money.ToString();

        currentLevelObj.SetActive(true);
    }

    private void Start()
    {
        setLevelStuffs();

    }
    public void win()
    {
        UIManager.instance.win.SetActive(true);
        UIManager.instance.WinMoneyText.text = "Total:"+money.ToString();
    }
    public void Lose()
    {
        UIManager.instance.lose.SetActive(true);
    }
    public void WinSelection()
    {
        PlayerPrefs.SetInt("Level",level+1);

        PlayerPrefs.SetFloat("Balance", money);

        PlayerPrefs.Save();
        SceneManager.LoadScene(0);

    }

    public void startGame()
    {
      
        UIManager.instance.Start.SetActive(false);
        GameManager.instance.speed = speed;
      GameManager.instance.character.SetAnimation("FallingIdle");

    }
 
    public void LoseGame()
    {
        SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
