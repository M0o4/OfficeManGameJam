using System;
using System.Collections;
using State;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Speak _speak;

    private void Start()
    {
        StartCoroutine(StartSpek());
    }

    private IEnumerator StartSpek()
    {
        yield return new WaitForSeconds(1f);
        _speak.StartSpeak();
    }
}
