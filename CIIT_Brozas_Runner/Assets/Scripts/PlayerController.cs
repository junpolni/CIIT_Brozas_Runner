using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float forwardSpeed = 4f;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(this.transform.forward * (forwardSpeed * Time.deltaTime));

        float horizontalMovement = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalMovement, 0, 0).normalized;
        transform.Translate(direction * (moveSpeed * Time.deltaTime));
    }
}
