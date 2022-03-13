using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Cube")
        {
            StackManager.instance.AddStack();
            Destroy(other.gameObject);
        }
        if (other.tag == "Obstacle")
        {
            StackManager.instance.RemoveStack(other.GetComponent<ObstacleProperty>().power);
            Destroy(other.gameObject);
        }
        if (other.tag == "Final")
        {
            GameManager.instance.speed = 0;
            GameManager.instance.addMoney(StackManager.instance.stackValue * 10);
            GameManager.instance.character.jumpFinal();
            for (int i = 0; i < GameManager.instance.particle.Length; i++)
            {
                GameManager.instance.particle[i].Play();

            }
            GameManager.instance.character.SetAnimation("Cheering");
            LevelManager.Instance.Invoke("win",0.5f);
      
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
