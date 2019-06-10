using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumberOnTheFloorsManager : MonoBehaviour
{
    NumbersManager numbersManagerScript;

    TextMeshProUGUI textMeshProUGUI;

    public int numberOnFloor;

    private void Start()
    {
        numbersManagerScript = NumbersManager.Instance;

        textMeshProUGUI = gameObject.GetComponentInChildren<TextMeshProUGUI>();

        StartCoroutine(TakeNumber());

    }

    IEnumerator TakeNumber()
    {
        
        yield return new WaitForSeconds(0.01f);

       
        if (Random.value < 0.3f)
        {
            transform.parent.gameObject.layer = 13;

            numberOnFloor = numbersManagerScript.primeNumbersList[Random.Range(0, numbersManagerScript.primeNumbersList.Count)];
            numbersManagerScript.numbersOnTheFloors.Add(numberOnFloor);
            numbersManagerScript.countOfEnd += 1;
        }
        else
        {
            transform.parent.gameObject.layer = 14;

            numberOnFloor = numbersManagerScript.nonPrimeNumbersList[Random.Range(0, numbersManagerScript.nonPrimeNumbersList.Count)];
        }    
        
        textMeshProUGUI.text = numberOnFloor.ToString();
    }

}
