using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera: MonoBehaviour
{
    public bool isFirstPerson = false;
    public Transform firstPersonPOV;
    public Transform thirdPersonPOV;

    public Vector3 initialPositionOffset;

    void Awake()
    {
        if (initialPositionOffset == null)
        {
            initialPositionOffset = transform.localPosition;
        }
    }

    void Start()
    {
        UpdateView();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ChangeView();
        }
    }

    public void ChangeView()
    {
        isFirstPerson = !isFirstPerson;
        UpdateView();
    }

    private void UpdateView()
    {
        if (isFirstPerson)
        {
            if (firstPersonPOV == null)
            {
                transform.localPosition = Vector3.zero;
            }
            else
            {
                transform.localPosition = firstPersonPOV.localPosition;
                transform.localRotation = firstPersonPOV.localRotation;
            }
        }
        else
        {
            if (thirdPersonPOV == null)
            {
                transform.localPosition = initialPositionOffset;
            }
            else
            {
                transform.localPosition = thirdPersonPOV.localPosition;
                transform.localRotation = thirdPersonPOV.localRotation;
            }
        }
    }
}