using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private const string IS_WALKING = "IsWalking";
    [SerializeField] private CharacterController player;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetBool(IS_WALKING, player.IsWalking());
    }
}
