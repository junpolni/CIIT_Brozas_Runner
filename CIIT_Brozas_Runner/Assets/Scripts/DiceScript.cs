using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 initialPos;
    bool hasLanded;
    bool thrown;
    int diceValue;
    [SerializeField] DiceSide[] _ds;
    [SerializeField] private Vector2 torqueValue;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPos = transform.position;
        _ds = GetComponentsInChildren<DiceSide>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) { RollDice(); }

        if (rb.IsSleeping() && !hasLanded && thrown)
        {
            hasLanded = true;
            rb.useGravity = false;
            rb.isKinematic = true;
        }
        else if (rb.IsSleeping() && hasLanded && diceValue == 0)
        {
            RollAgain();
        }
    }

    void RollDice()
    {
        if (!thrown && !hasLanded)
        {
            thrown = true;
            rb.useGravity = true;
            rb.AddTorque(  
                Random.Range(torqueValue.x, torqueValue.y), 
                Random.Range(torqueValue.x, torqueValue.y), 
                Random.Range(torqueValue.x, torqueValue.y));
        }
        else if (thrown && hasLanded)
        {
            ResetDice();
        }
    }

    void ResetDice()
    {
        transform.position = initialPos;
        thrown = false;
        hasLanded = false;
        rb.useGravity = false;
        rb.isKinematic = false;
    }

    void RollAgain()
    {
        ResetDice();
        thrown = true;
        rb.useGravity = true;
        rb.AddTorque(
                Random.Range(torqueValue.x, torqueValue.y),
                Random.Range(torqueValue.x, torqueValue.y),
                Random.Range(torqueValue.x, torqueValue.y));
    }
}