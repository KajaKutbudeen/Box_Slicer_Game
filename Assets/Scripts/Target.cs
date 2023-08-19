using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    Rigidbody Targetrb;
    float MinSpeed = 12;
    float MaxSpeed = 14;
    float Torque = 10;
    
    float PosX = 2.2f;
    float PosY = 0.2f;
    GameManager gameManager;
    [SerializeField]
    int pointvalue;
    public GameObject explosion;

    private void Start()
    {
        Targetrb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        Targetrb.AddForce(RandomForce(), ForceMode.Impulse);
        Targetrb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque());
        transform.position = SpawnPos();
    }
    private void Update()
    {
        if (transform.position.y < -0.5)
        {
            gameManager.UpdateScore(-pointvalue);
            Destroy(gameObject);
        
        }
    }

    public void DestroyTarget()
    {
        gameManager.UpdateScore(pointvalue);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);   
    }

    private float RandomTorque()
    {
        return Random.Range(-Torque, Torque);
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(MinSpeed, MaxSpeed);
    }
    private Vector3 SpawnPos()
    {
        return new Vector3(Random.Range(-PosX, PosX), PosY, 0);
    }

   
}
