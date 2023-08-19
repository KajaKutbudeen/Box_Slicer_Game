using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer), typeof(BoxCollider))]
public class ClickandSwipe : MonoBehaviour
{
    private Camera _camera;
    private GameManager gameManager;
    private Vector3 MousePos;
    private TrailRenderer trailRenderer;
    private BoxCollider boxCollider;
    private bool isswipe =false;

    private void Awake()
    {
        _camera = Camera.main;
        trailRenderer = GetComponent<TrailRenderer>();
        boxCollider = GetComponent<BoxCollider>();
        trailRenderer.enabled = false;
        boxCollider.enabled = false;

        gameManager =  GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    private void Update()
    {
        if(gameManager.isActiveAndEnabled)
        {
            if(Input.GetMouseButtonDown(0))
            {
                isswipe = true;
                UpdateComponent();
            }
            else if(Input.GetMouseButtonUp(0))
            {
                isswipe = false;
                UpdateComponent();
            }
            if(isswipe)
            {
                UpdateMousePos();
            }
        }
    }
    void UpdateMousePos()
    {
        MousePos = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        transform.position = MousePos;
    }
    void UpdateComponent()
    {
        trailRenderer.enabled = isswipe;
        boxCollider.enabled = isswipe;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Target>())
        {
            collision.gameObject.GetComponent<Target>().DestroyTarget();
        }
    }
}
