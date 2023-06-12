using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    AudioSource audioSource;
    Rigidbody rb;
    [SerializeField] float boostSpeed = 10f;
    [SerializeField] float rotationSpeed = .3f; 

    private void Start() {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update() {
        ProcessRotation();
        ProcessBoost();

    }
   void ProcessRotation()
   {
        if(Input.GetKey(KeyCode.D))
        {
            ApplyRotate(-rotationSpeed);
        }
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotate(rotationSpeed);
        }
   }

   void ProcessBoost()
   {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(new Vector3(0,boostSpeed,0));
            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
       
   }

   void ApplyRotate(float pos)
   {
    rb.freezeRotation = true;
    transform.Rotate(new Vector3(0, 0, pos) * Time.deltaTime);
    rb.freezeRotation = false;
   }
}

