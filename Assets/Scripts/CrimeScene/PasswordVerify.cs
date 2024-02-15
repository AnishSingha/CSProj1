using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PasswordVerify : MonoBehaviour
{

    [SerializeField] public TMP_InputField passWord;


    public void VerifyPassword()
    {
        if (passWord.text == "Password12345")
        {
            Debug.Log("Correct Password");
        }
        else
        {
            Debug.Log("Invalid Password");
        }
    }
}
