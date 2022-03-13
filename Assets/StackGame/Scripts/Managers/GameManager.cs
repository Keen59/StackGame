using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;
    [Header("Character Properties")]
    public float speed;
    public CharacterController character;
    [Header("Camera Properties")]

    public CinemachineVirtualCamera characterCamera;
    [Header("End Properties")]
    public GameObject end;
    public ParticleSystem[] particle;

    bool speedUpStart;
    private void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
    
    }

    public void ShakeCamera()
    {
        characterCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 2;
        characterCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 2;
        Invoke("ShakeCameraStop",.5f);
    }

    public void ShakeCameraStop()
    {
        characterCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
        characterCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 0;
    }
    public void ChangeOffset(float distance)
    {
        characterCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = new Vector3(characterCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.x, characterCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.y, characterCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset.z + distance);
    }
    public void addMoney(float price)
    {
        LevelManager.Instance.money += price;
    }
    public void speedUp()
    {
        if (!speedUpStart)
        {
            speed = LevelManager.Instance.speed + 5;
            speedUpStart = true;
        }
    }
    float waiting;
    // Update is called once per frame
    void Update()
    {
        if (speedUpStart)
        {
            waiting += Time.deltaTime;
            if (waiting>=5)
            {
                speed = LevelManager.Instance.speed;
                waiting = 0;

                speedUpStart = false;
            }
        }   
    }
}
