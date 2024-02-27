using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PasswordVerify : MonoBehaviour
{

    [SerializeField] public TMP_InputField passWord;
    [SerializeField] GameObject correctPassword;
    [SerializeField] GameObject IncorrectPassword;
    
    public void VerifyPassword()
    {
        if (passWord.text == "Dontdisturbme12345")
        {
            Debug.Log("Correct Password");
            correctPassword.SetActive(true);
            IncorrectPassword.SetActive(false);

        }
        else
        {
            Debug.Log("Invalid Password");
            IncorrectPassword.SetActive(true);
            correctPassword.SetActive(false);

        }
    }
}
