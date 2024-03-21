using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PasswordVerify : MonoBehaviour
{

    [SerializeField] public TMP_InputField passWord;
    [SerializeField] GameObject correctPassword;
    [SerializeField] GameObject IncorrectPassword;
    [SerializeField] GameObject NextSceneText;

    [HideInInspector]public bool CanSwitchScene = false;


    public void VerifyPassword()
    {
        if (passWord.text == "Dontdisturbme12345")
        {
            Debug.Log("Correct Password");
            correctPassword.SetActive(true);
            IncorrectPassword.SetActive(false);
            CanSwitchScene = true;

        }
        else
        {
            Debug.Log("Invalid Password");
            IncorrectPassword.SetActive(true);
            correctPassword.SetActive(false);

        }
    }

   
    private void Update()
    {
        if (CanSwitchScene == true)
        {
            NextSceneText.SetActive(true);
            if (Input.GetKey(KeyCode.Space))
            {

                SceneManager.LoadScene("VictimCase");
            }
        }
        
    }

}
