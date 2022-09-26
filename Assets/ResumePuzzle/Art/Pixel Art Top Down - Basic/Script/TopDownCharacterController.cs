﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed;
        [SerializeField] private Joystick joystick;   
        private Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            Vector2 dir = joystick.Direction;
            
            animator.SetBool("IsMoving", dir.magnitude > 0);
            animator.SetFloat("DirectionX", dir.x);
            animator.SetFloat("DirectionY", dir.y);

            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }
    }
}
