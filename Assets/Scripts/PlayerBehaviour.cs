using DG.Tweening;
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
    public ParticleSystem EndParticle;

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
            other.gameObject.GetComponent<CollectableBehaviour>().Collect();
        }
        else if (other.gameObject.CompareTag("Obstacle") && isDead==false)
        {
            animatorController.PlayDeath();
            playerMovement.enabled = false;
            StartCoroutine(Respawn(3));
            isDead = true;

               
        }

        if (other.gameObject.CompareTag("Ending"))
        {

            animatorController.PlayJoy();
            playerMovement.enabled = false;
            StartCoroutine(Respawn(6));
            transform.DORotate(new Vector3(0, 180, 0), 0.5f);
            EndParticle.Play(true);
            other.enabled = false;

        }

    }
    private IEnumerator Respawn(int waitDuration)
    {
        yield return new WaitForSeconds(waitDuration);
        SceneManager.LoadScene(0);
        isDead = false;
        //transform.position = initialPosition;
        //transform.rotation = initialRotation;
        //animatorController.PlayIdle();
        //playerMovement.enabled = true;
          
    }
}
