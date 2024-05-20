using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class AssigToVirtualCamera : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public string[] characterNames;
    void Update()
    {
        foreach (string name in characterNames)
        {
            GameObject character = GameObject.Find(name);
            if (character != null)
            {
                virtualCamera.Follow = character.transform;
                virtualCamera.LookAt = character.transform;
                break;

            }
        }
        
    }
}
