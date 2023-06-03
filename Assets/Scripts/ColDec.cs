using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColDec : MonoBehaviour
{
    public Katana katana;
    public Camera cum;
    public AudioClip SlashObjSound;
    public AudioClip SlashAirSound;

    private void Update()
    {
        Vector3 direction = Vector3.forward;
        Debug.DrawRay(cum.transform.position, cum.transform.TransformDirection(direction * katana.KatanaRange)); //Луч для проверки дальности атаки
    }
    public void Shoot_Sound() //Проверка на чём прицел
    {
        RaycastHit hit;
        if (Physics.Raycast(cum.transform.position, cum.transform.forward, out hit, katana.KatanaRange))
        {
            Debug.Log(hit.collider);
            if (hit.collider.tag == "Obj")
            {
                AudioSource sos = GetComponent<AudioSource>();
                sos.PlayOneShot(SlashObjSound);
            }
            if (hit.collider.tag == "Enemy")
            {   
            }
        }
        else
        {
            AudioSource sas = GetComponent<AudioSource>();
            sas.PlayOneShot(SlashAirSound);
        }
    }
}
