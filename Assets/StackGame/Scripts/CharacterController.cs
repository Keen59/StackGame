using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterController : MonoBehaviour
{


  
    public SlideController Sc;

    private Transform currentBridge;
    private Transform currentLadder;
    [HideInInspector]
    public Transform LastLadderHolder;
    [HideInInspector]
    public Rigidbody rb;
    public Transform CharacterModel;
    Animator anim;

    Vector3 m_Velo;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }
   
    

   
  
   
 
    public void PlayerSpeed()
    {
        GameManager.instance.speed = 0;

    }
    public void SetAnimationBool(bool animationBool)
    {
        if (anim.GetBool("Run")!=animationBool)
        {
            anim.SetBool("Run", animationBool);
        }
    }
 
  
    public void SetAnimation(string animationName)
    {
        if (!this.anim.GetCurrentAnimatorStateInfo(0).IsName(animationName))
            anim.Play(animationName);
    }
    public void jumpFinal()
    {
        StackManager.instance.stack.parent = null;
        CharacterModel.parent = null;
        GameManager.instance.characterCamera.Follow = CharacterModel;
        CharacterModel.DOJump(GameManager.instance.end.transform.position,1,1,0.5f);
    }
    private void FixedUpdate()
    {
        //Vector3 target = new Vector3(0, rb.velocity.y, Time.deltaTime * GameManager.instance.speed);
        //rb.velocity = Vector3.SmoothDamp(rb.velocity, target, ref m_Velo, .05f);
        ////  rb.velocity =Vector3.forward*GameManager.instance.speed*Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+ GameManager.instance.speed * Time.fixedDeltaTime);

    }
}
