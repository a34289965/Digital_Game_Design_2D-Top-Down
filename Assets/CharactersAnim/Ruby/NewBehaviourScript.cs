using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Vector2 lookiDirection;
    private Vector2 rubyPosition;
    private Vector2 rubyMove;

    public Animator rubyAnimator;
    public Rigidbody2D rb;

    public float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        rubyAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rubyPosition = transform.position;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        print("Horizintal is: " + horizontal);
        print("Vertical is: " + vertical);

        rubyMove = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(rubyMove.x, 0) || !Mathf.Approximately(rubyMove.y, 0))
        {
            lookiDirection = rubyMove;
            lookiDirection.Normalize();
        }

        rubyAnimator.SetFloat("X", lookiDirection.x);
        rubyAnimator.SetFloat("Y", lookiDirection.y);
        rubyAnimator.SetFloat("Speed", rubyMove.magnitude);

        rubyPosition = rubyPosition + speed * rubyMove * Time.deltaTime;
        rb.MovePosition(rubyPosition);
    }
}