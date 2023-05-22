using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private AnimatorController animatorController;
    [SerializeField] private PlayerMovement playerMovement;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private bool isDead;

    private void Awake()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        isDead = false;
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);
            
        }
        else if (other.gameObject.CompareTag("Obstacle") && isDead==false)
        {
            animatorController.PlayDeath();
            playerMovement.enabled = false;
            StartCoroutine(Respawn());
            isDead = true;

               
        }

    }
    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
        isDead = false;
        //transform.position = initialPosition;
        //transform.rotation = initialRotation;
        //animatorController.PlayIdle();
        //playerMovement.enabled = true;
          
    }
}
