using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorController : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayIdle()
    {
        _animator.SetBool("Run", false);
    }

    public void PlayRun()
    {
        _animator.SetBool("Run", true);

    }

    internal void PlayDeath()
    {
        _animator.SetTrigger("Death");
    }

    public void PlayJoy()
    {

        _animator.SetTrigger("Joy");

    }
}
