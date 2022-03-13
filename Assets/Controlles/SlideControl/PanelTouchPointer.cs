using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelTouchPointer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public SlideController CharacterController;
    // Start is called before the first frame update
    public void OnPointerDown(PointerEventData eventData)
    {
        CharacterController.ScreenTouchDown();
    }

 
    public void OnPointerUp(PointerEventData eventData)
    {
        CharacterController.ScreenTouchUp();

    }
}
