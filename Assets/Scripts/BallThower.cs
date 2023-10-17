using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThower : MonoBehaviour
{
    private GameObject Ball;

    private float startTime, endTime, swipeDistance, swipeTime;
    private Vector2 startPos, endPos;

    private float ballVelocity;
    private float ballSpeed;
    public float maxBallSpeed;
    private Vector3 angle;

    private bool throwing, holding;
    private Vector3 newPosition;

    private Rigidbody rb;

    private void Start()
    {
        SetupBall();
    }

    void SetupBall()
    {
        GameObject _ball = GameObject.FindGameObjectWithTag("Player");
        Ball = _ball;
        rb = Ball.GetComponent<Rigidbody>();
        ResetBall();
    }

    public void ResetBall()
    {
        startPos = Vector2.zero;
        endPos = Vector2.zero;
        angle = Vector3.zero;

        ballSpeed = 0;
        startTime = 0;
        endTime = 0;
        swipeDistance = 0;
        swipeTime = 0;
        throwing = false;
        holding = false;

        rb.velocity = Vector3.zero;
        rb.useGravity = false;

        Ball.transform.position = transform.position;
    }

    void PickUpBall()
    {
        Vector3 touchPos = Input.GetTouch(0).position;
        touchPos.z = Camera.main.nearClipPlane * 12f;
        newPosition = Camera.main.ScreenToWorldPoint(touchPos);
        Ball.transform.position = Vector3.Lerp(Ball.transform.localPosition, newPosition, 80f * Time.deltaTime);
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            if (holding)
            {
                PickUpBall();
            }

            if (throwing)
            {
                return;
            }

            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit _hit;

                if (Physics.Raycast(ray, out _hit, 100f))
                {
                    if (_hit.transform == Ball.transform)
                    {
                        startTime = Time.time;
                        startPos = touch.position;
                        holding = true;
                    }
                }
            }

            else if (touch.phase == TouchPhase.Ended)
            {
                endTime = Time.time;
                endPos = touch.position;
                swipeDistance = (endPos - startPos).magnitude;
                swipeTime = endTime - startTime;

                if (swipeTime < 0.5f && swipeDistance > 30f)
                {
                    CalSpeed();
                    CalAngle();
                    rb.AddForce(new Vector3(angle.x * ballSpeed, angle.y * ballSpeed, -(angle.z * ballSpeed)));
                    rb.useGravity = true;
                    holding = false;
                    throwing = true;
                    Invoke("ResetBall", 4f);
                }
                else
                {
                    ResetBall();
                }
            }
        }   
    }

    void CalSpeed()
    {
        angle = Camera.main.ScreenToWorldPoint(new Vector3(endPos.x, endPos.y + 50f, Camera.main.nearClipPlane + 5));
    }
    
    void CalAngle()
    {
        if(swipeTime > 0)
        {
            ballVelocity = swipeDistance / (swipeDistance = swipeTime);
        }

        ballSpeed = ballVelocity * 40f;

        if(ballSpeed >= maxBallSpeed)
        {
            ballSpeed = maxBallSpeed;
        }

        if(ballSpeed <= maxBallSpeed)
        {
            ballSpeed = ballSpeed += 40;
        }

        swipeTime = 0;
    }
}
