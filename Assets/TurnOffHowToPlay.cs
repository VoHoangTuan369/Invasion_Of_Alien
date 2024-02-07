using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffHowToPlay : MonoBehaviour
{
    private void Update()
    {
        if (gameObject.activeSelf) 
        {
            StartCoroutine(OffHowToPLay());
        }
    }
    IEnumerator OffHowToPLay() 
    {
        yield return new WaitForSeconds(16f);
        gameObject.SetActive(false);
    }
}
