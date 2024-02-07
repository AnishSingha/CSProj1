using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class InputManager : MonoBehaviour
{

    [SerializeField] SplineMovement SplineMovement;
    private int InputCount = 0;

    [SerializeField] public VideoPlayer Player;
    [SerializeField] public GameObject phone;

    private void Start()
    {
        SplineMovement = GetComponent<SplineMovement>();
    }
    void Update()
    {
        if (InputCount <= 1)
        {
            RotateCamera();

        }
        if (SplineMovement.t == 1)
        {
            SplineMovement.enabled = false;
        }

    }

    public void RotateCamera()
    {
        
        if (Input.GetKeyDown(KeyCode.E) & SplineMovement.t == 1)
        {
            InputCount++;   
            transform.Rotate(Vector3.right , 20f);
            Player.enabled = true;
            phone.SetActive(true);
        }
    }
}
