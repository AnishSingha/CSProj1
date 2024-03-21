using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RaycastFromPoint : MonoBehaviour
{
    public float raycastDistance = 1000f;
    public Animator animator;
    public GameObject excuseMeButton;


    public GameObject twoFactorAuthentication;
    public GameObject quitIcon;
    public GameObject UseDiffComb;
    public GameObject Awareness;
    public GameObject UseSpaceHint;

    [SerializeField] GameObject Welcome;
    [SerializeField] GameObject Success;
    [SerializeField] GameObject Finish;
    [SerializeField] GameObject ShowHide;


    private int shooCount = 0;

    private void Start()
    {
        StartCoroutine(StartScene());
    }

    IEnumerator StartScene()
    {
        yield return new WaitForSeconds(4f);
        Welcome.SetActive(false);
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            if (hit.collider.CompareTag("RaycastBox"))
            {
                excuseMeButton.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Space) && shooCount == 0)
                {
                    animator.SetTrigger("TurnRight");
                    StartCoroutine(WaitforMove());
                    shooCount++;
                    excuseMeButton.SetActive(false);


                    

                    Awareness.SetActive(false);
                    UseSpaceHint.SetActive(false);

                    StartCoroutine(Successfull());
                }
                if (shooCount >= 1)
                {
                    excuseMeButton.SetActive(false);

                }

            }
            else
            {
                
                excuseMeButton.SetActive(false);

            }
            Debug.DrawLine(transform.position, hit.point, Color.green);
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.forward * raycastDistance, Color.red);
        }
    }

    public IEnumerator WaitforMove()
    {
        
        yield return new WaitForSeconds(4f);
        animator.SetTrigger("Idle");
    }

    public IEnumerator Successfull()
    {
        yield return new WaitForSeconds(3f);
        Success.SetActive(true);
        yield return new WaitForSeconds(3f);
        Success.SetActive(false);
        twoFactorAuthentication.SetActive(true);
        UseDiffComb.SetActive(true);
        ShowHide.SetActive(true);
        yield return new WaitForSeconds(5f);
        //twoFactorAuthentication.SetActive(false);
        //UseDiffComb.SetActive(false);
        //Finish.SetActive(true);
        //yield return new WaitForSeconds(3f);


        quitIcon.SetActive(true);

        


    }
}


