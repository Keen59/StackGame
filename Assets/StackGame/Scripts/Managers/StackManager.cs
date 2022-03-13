using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackManager : MonoBehaviour
{
    public static StackManager instance;


    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        
    }
    public Transform StackTarget;


    public Transform stack;


    public int stackValue;

   public float yDistance;

    public void AddStack()
    {



        stack.transform.DOScaleY(stack.transform.localScale.y+0.25f, 0.5f).OnComplete(() => stack.transform.DOLocalMoveY(-stack.transform.localScale.y / 2, 0.2f));
       
       // stack.transform.DOLocalMoveY(-0.25f, 0.5f);
        GameManager.instance.character.CharacterModel.DOLocalMoveY(GameManager.instance.character.CharacterModel.localPosition.y+0.25f,0.2f);
        stackValue++;
        GameManager.instance.ChangeOffset(-.5f);
      
      

    }
    public void RemoveStack(float scale)
    {



        stack.transform.DOScaleY(stack.transform.localScale.y - scale, 0.5f).OnComplete(() => stack.transform.DOLocalMoveY(-stack.transform.localScale.y / 2, 0.2f));

        // stack.transform.DOLocalMoveY(-0.25f, 0.5f);
        GameManager.instance.character.CharacterModel.DOLocalMoveY(GameManager.instance.character.CharacterModel.localPosition.y - scale, 0.2f);
        if (scale==.5f)
        {
            stackValue-=2;

        }
        else
        {
            stackValue--;
        }
        GameManager.instance.ChangeOffset(+.5f);

        stackControl();

    }
    public void stackControl()
    {
        if (stackValue<=0)
        {
            GameManager.instance.character.CharacterModel.DOLocalMoveY(GameManager.instance.character.CharacterModel.localPosition.y - 0.5f, 0.2f);
            stack.DOScale(stack.transform.localScale+Vector3.one/2,0.2f).OnComplete(() => stack.transform.DOScale(0, 0.2f));
            Destroy(stack.gameObject,0.5f);
            GameManager.instance.speed = 0;
            GameManager.instance.character.SetAnimation("FallFlat");
            LevelManager.Instance.Lose();
        }
    }
    void LateUpdate()
    {
       
    }
}
