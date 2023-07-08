using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : MonoBehaviour
{
    [SerializeField] GameObject[] instructions;

    GameObject currentInstruction;
    void Start()
    {
        currentInstruction = instructions[0];
    }

    public void NextInstruction(int index)
    {
        currentInstruction.gameObject.SetActive(false);

        currentInstruction = instructions[index];
        currentInstruction.SetActive(true);
    }
}
