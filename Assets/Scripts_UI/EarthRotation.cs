using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor.Rendering;
using UnityEngine;

public class EarthRotation : MonoBehaviour
{

    
    private bool mouseRotationEnabled = false;
    private bool keyRotationEnabled = false;
    private Vector3 horizontalRotation = new Vector3(0f, 0f, 0f);
    private Vector3 verticalRotation = new Vector3(0f, 0f, 0f);

    private float xAxeRotation = 0f;

    private float mouseSensitivity = 5f;
    private float speed = 100f;

    // Object used to vertical rotation
    private GameObject earthBox;

    void Start()
    {
        earthBox = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetMouseButtonDown(1))
        {
            mouseRotationEnabled = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetMouseButtonUp(1))
        {
            mouseRotationEnabled = false;
        }


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            keyRotationEnabled = true;
            doEarthRotation("Right");
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            keyRotationEnabled = true;
            doEarthRotation("Left");
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            keyRotationEnabled = true;
            doEarthRotation("Up");
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            keyRotationEnabled = true;
            doEarthRotation("Down");
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            keyRotationEnabled = false;
            doEarthRotation("Right");
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            keyRotationEnabled = false;
            doEarthRotation("Left");
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            keyRotationEnabled = false;
            doEarthRotation("Up");
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            keyRotationEnabled = false;
            doEarthRotation("Down");
        }

        // Earth rotation
        if (mouseRotationEnabled)
        {
            EarthRotate();

        } else if (keyRotationEnabled)
        {
            rotateByKey();
        }


    }

    private void rotateByKey()
    {
        transform.Rotate(horizontalRotation * Time.deltaTime);
        earthBox.transform.Rotate(verticalRotation * Time.deltaTime);
    }


   

    // Update rotation values
    void doEarthRotation(string direction)
    {

        switch (direction)
        {
            case "Right":
                horizontalRotation = new Vector3(0f, -speed, 0f);
                verticalRotation = new Vector3(0f, 0f, 0f);
                break;

            case "Left":
                horizontalRotation = new Vector3(0f, speed, 0f);
                verticalRotation = new Vector3(0f, 0f, 0f);
                break;

            case "Up":
                horizontalRotation = new Vector3(0f, 0f, 0f);
                verticalRotation = new Vector3(-speed, 0f, 0f);
                break;

            case "Down":
                horizontalRotation = new Vector3(0f, 0f, 0f);
                verticalRotation = new Vector3(speed, 0f, 0f);
                break;

            default:
                break;
        }
    }


    
    // Mouse rotation
    void EarthRotate()
    {

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Horizontal rotation
        transform.Rotate(new Vector3(0f, -mouseX, 0f));

        // Vertical rotation
        xAxeRotation += mouseY;
        xAxeRotation = Mathf.Clamp(xAxeRotation, -30f, 30f);
        earthBox.transform.localRotation = Quaternion.Euler(xAxeRotation, 0f, 0f);

    }


    private void OnMouseDown()
    {
        Debug.Log("Mouse Down Earth");
    }

    public void enableRotation()
    {
        Debug.Log("Ctrl Down ");
    }

    public void disableRotation()
    {
        Debug.Log("Ctrl Up");
    }

}
