using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{

    [SerializeField] SplineMovement SplineMovement;
    private int InputCount = 0;
    private bool canSwitchScene;

    [SerializeField] public VideoPlayer Player;
    [SerializeField] public GameObject phone;
    [SerializeField] public GameObject SwitchScenetext;
    [SerializeField] public GameObject SuccessfulUI;


    private void Start()
    {
        SplineMovement = GetComponent<SplineMovement>();
    }
    void Update()
    {
        CanSwitchScene();

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
            StartCoroutine(SwitchSceneCountdownCourotine());
            SuccessfulUI.SetActive(true);
        }
    }

    public IEnumerator SwitchSceneCountdownCourotine()
    {
        yield return new WaitForSeconds(19f);
        canSwitchScene = true;

    }
    public void CanSwitchScene()
    {
        
        if (canSwitchScene == true)
        {
            SwitchScenetext.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {                
                SceneManager.LoadScene("CrimeScene");
            }
        }
    }
}
