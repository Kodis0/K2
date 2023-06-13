using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject katana;
    public GameObject grappleGun;
    public GameObject player;

    private void Start()
    {
        player.GetComponent<Katana>().enabled = true;
        player.GetComponent<Grappling>().enabled = false;
        player.GetComponent<SwingingDone>().enabled = false;
        Animator anim = katana.GetComponent<Animator>();
        anim.SetBool("Ready", true);
        grappleGun.SetActive(false);
    }
    void Update()
    {
        UseWeapon();
    }
    public void UseWeapon()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            player.GetComponent<Katana>().enabled = true;
            player.GetComponent<Grappling>().enabled = false;
            player.GetComponent<SwingingDone>().enabled = false;
            Animator anim = katana.GetComponent<Animator>();
            anim.SetBool("Ready", true);
            grappleGun.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            player.GetComponent<Katana>().enabled = false;
            player.GetComponent<Grappling>().enabled = true;
            player.GetComponent<SwingingDone>().enabled = true;
            Animator anim = katana.GetComponent<Animator>();
            anim.SetBool("Ready", false);
            grappleGun.SetActive(true);
        }
    }
}
