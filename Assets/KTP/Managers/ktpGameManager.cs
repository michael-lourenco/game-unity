using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ktpGameManager : MonoBehaviour
{
    public List<Transform> wayPoints;
    private ktpStateController[] _controllers;

    private void Start() {
        _controllers = FindObjectsOfType<ktpStateController>();
        foreach(var controller in _controllers)
            controller.InitializeAI(true, wayPoints);
    }

    private void Update() {
        _controllers = FindObjectsOfType<ktpStateController>();
        foreach(var controller in _controllers)
            controller.InitializeAI(true, wayPoints);
    }
}
