using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleGameStarter : MonoBehaviour
{
    [SerializeField] private Vector3 startCameraPosition;
    [SerializeField] private Transform transformCameraForGame;
    [SerializeField] private GameObject appleGame;
    [SerializeField] private GameObject game;
    [SerializeField] private CameraMovement cameraMovement;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerMovement player))
        {
            appleGame.SetActive(true);
            game.SetActive(false);
            cameraMovement.enabled = false;
            transformCameraForGame.position = startCameraPosition;
        }
    }
}
