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

    public SplineMovement splineMovement;

    private int shooCount = 0;

    
    

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


                    twoFactorAuthentication.SetActive(true);
                    quitIcon.SetActive(true);
                    UseDiffComb.SetActive(true);

                    Awareness.SetActive(false);
                    UseSpaceHint.SetActive(false);
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
}


