using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : MonoBehaviour
{
    [SerializeField]
    private GameObject imageBackground;
    [SerializeField]
    private GameObject imageController;
    private Vector3 stickFristPosition;
    public Vector3 joyVec;
    float StickRadius;

    public void Awake()
    {
        StickRadius = imageBackground.gameObject.GetComponent<RectTransform>().sizeDelta.y / 6;
        Debug.Log(StickRadius);
    }

    public void PointerDown()
    {
        imageBackground.SetActive(true);
        imageBackground.transform.position = Input.mousePosition;
        imageController.transform.position = Input.mousePosition;
        stickFristPosition = Input.mousePosition;
    }

    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector3 DragPosition = pointerEventData.position;
        joyVec = (DragPosition - stickFristPosition).normalized;

        float stickDistance = Vector3.Distance(DragPosition, stickFristPosition);

        if (stickDistance < StickRadius)
        {
            imageController.transform.position = stickFristPosition + joyVec * stickDistance;
        }
        else
        {
            imageController.transform.position = stickFristPosition + joyVec * StickRadius;
        }
    }

    public void Drop()
    {
        joyVec = Vector3.zero;
        imageBackground.SetActive(false);
    }
}
