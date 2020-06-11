using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class playerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public float incY;
    public float maxHeigth;
    public float minHeigth;

    public GameObject deathMenu;
    [Header("Swipes")]
    public float maxSwapTime;
    public float minSwipeDistance;

    private Rigidbody2D _rigidbody;
    private Collider2D _circleCollider;
    private Animator _animator;
    private Transform _transform;

    private float swipeStartTime;
    private float swipeEndTime;
    private float swipeTime;

    private Vector2 startSwipePosition;
    private Vector2 endSwipePosition;
    private float swipeLength;


    enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    private void Awake()
    {
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("3647585");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _circleCollider = GetComponent<CircleCollider2D>();
        _animator = GetComponent<Animator>();
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        Animate();
    }

    void FixedUpdate()
    {
        Controls();
    }

    private void Controls()
    {
        if(GetInput(Direction.Up))
        {
            Move(Direction.Up);
        }
        if(GetInput(Direction.Down))
        {
            Move(Direction.Down);
        }
    }

    private void Animate()
    {
        _animator.SetFloat("velocity",_rigidbody.velocity.y);
    }


    private void Move(Direction dir)
    {
        switch(dir)
        {
            case Direction.Up:
                if(_transform.position.y<maxHeigth)
                    _transform.position += Vector3.up * incY;
                break;
            case Direction.Down:
                if (_transform.position.y > minHeigth)
                    _transform.position += Vector3.down * incY;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Lose();
        }
    }

    private void Lose()
    {
        deathMenu.SetActive(true);
        Time.timeScale = 0;
    }

    private bool GetInput(Direction dir)
    {
        if(PCControls(dir)) return true;
        if (AndroidControls(dir)) return true;
        return false;
        
    }

    private bool PCControls(Direction dir)
    {
        switch (dir)
        {
            case Direction.Up:
                return (Input.GetKeyDown(KeyCode.UpArrow));// || Input.GetTouch(0).phase == TouchPhase.Moved);
            case Direction.Down:
                return (Input.GetKeyDown(KeyCode.DownArrow));// || Input.GetTouch(0).phase == TouchPhase.Moved);
            case Direction.Left:
                return (Input.GetKey(KeyCode.LeftArrow));// || Input.GetTouch(0).phase == TouchPhase.Moved);
            case Direction.Right:
                return (Input.GetKey(KeyCode.RightArrow));// || Input.GetTouch(0).phase == TouchPhase.Moved);
            default: return false;
        }
    }

    private bool AndroidControls(Direction dir)
    {
        if (!SwipeTest()) return false;

        Direction realDir;

        Vector2 Distance = endSwipePosition - startSwipePosition;

        float DistanceX = Mathf.Abs(Distance.x);
        float DistanceY = Mathf.Abs(Distance.y);

        if(DistanceX < DistanceY)
        {
            if (Distance.y < 0)
                realDir = Direction.Down;
            else               
                realDir = Direction.Up;
        }
        else
        {
            if (Distance.x < 0)
                realDir = Direction.Left;
            else              
                realDir = Direction.Right;
        }

        return (dir == realDir);
    }

    private bool SwipeTest()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                swipeStartTime = Time.time;
                startSwipePosition = touch.position;
            }
            else
            if (touch.phase == TouchPhase.Ended)
            {
                swipeEndTime = Time.time;
                endSwipePosition = touch.position;
                swipeTime = swipeEndTime - swipeStartTime;
                swipeLength = (endSwipePosition - startSwipePosition).magnitude;
                return (swipeTime < maxSwapTime && swipeLength > minSwipeDistance);
            }
        }
        return false;
    }


}
