using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;



 
    public GameObject win;
    public GameObject Start;
    public GameObject lose;

    public Text lvltext;
    public Text Balancetext;
    public Text WinMoneyText;


 
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

    }
    
  
    // Update is called once per frame
    void Update()
    {
        
    }
}
