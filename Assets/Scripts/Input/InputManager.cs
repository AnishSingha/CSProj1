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
    [SerializeField] public GameObject GameStartUI;
    public GameObject PressE;
    bool pressedE = false;

    private void Start()
    {
        Time.timeScale = 0.0f;
        SplineMovement = GetComponent<SplineMovement>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Time.timeScale = 1.0f;
            GameStartUI.SetActive(false);
        }

        CanSwitchScene();

        if (InputCount <= 1)
        {
            RotateCamera();

        }
        if (SplineMovement.t == 1)
        {
            
            if (pressedE == false)
            {
                PressE.SetActive(true);
                
            }
            SplineMovement.enabled = false;
        }
        if (pressedE == true)
        {
            PressE.SetActive(false);
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
            pressedE = true;
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
