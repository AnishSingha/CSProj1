using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RaycastFromPoint : MonoBehaviour
{
    public float raycastDistance = 1000f;
    public Animator animator;
    public GameObject excuseMeButton;
    public SplineMovement splineMovement;
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            if (hit.collider.CompareTag("RaycastBox"))
            {
                excuseMeButton.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    animator.SetTrigger("TurnRight");
                    StartCoroutine(WaitforMove());
                    
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


