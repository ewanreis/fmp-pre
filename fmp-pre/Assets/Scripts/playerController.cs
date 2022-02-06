using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerController : MonoBehaviour
{   Helper Helper = new Helper();
    Animator anim;
    void Start() 
    {
        anim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update() => Helper.PlayerState();
    void FixedUpdate() => Helper.MovePlayer();
}