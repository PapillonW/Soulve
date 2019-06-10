using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NumbersManager : MonoBehaviour
{
    private static NumbersManager _instance;
    public static NumbersManager Instance { get { return _instance; } }


    public List<int> numbersList;
    public List<int> primeNumbersList;
    public List<int> nonPrimeNumbersList;
    public List<int> numbersOnTheFloors;

    public int numberListCount;

    public int countOfEnd;

    private void Awake()
    {
        _instance = this;

        numbersList = new List<int>();
        primeNumbersList = new List<int>();
        nonPrimeNumbersList = new List<int>();
        numbersOnTheFloors = new List<int>();
    }

    private void Start()
    {

        for (int x = 2; x < numberListCount; x++)
        {
            numbersList.Add(x);
        }

        for (int i = 2; i < numbersList.Count + 2; i++)
        {
            int control = 0;
            for (int w = 2; w < i; w++)
            {
                if (i % w == 0)
                {
                    control = 1;
                }               
            }
            if (control == 1)
            {
                nonPrimeNumbersList.Add(i);
            }
        }

        nonPrimeNumbersList.Add(0);
        nonPrimeNumbersList.Add(1);

        primeNumbersList = numbersList.Except(nonPrimeNumbersList).ToList();                      
    }
}
