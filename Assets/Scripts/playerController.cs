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
    public float speedInc;

    public GameObject deathMenu;
    [Header("Swipes")]
    public float maxSwapTime;
    public float minSwipeDistance;

    private Rigidbody2D _rigidbody;
    private Collider2D _circleCollider;
    private Animator _animator;
    private Transform _transform;

    static public bool alive;
    private Coroutine currCoroutine = null;


    private void Awake()
    {
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("3647585");
        }
        alive = true;
        Controls.maxSwapTime = maxSwapTime;
        Controls.minSwipeDistance = minSwipeDistance;
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
        //Debug.Log("Update: " + Time.deltaTime);
        if (alive)
        {
            TryControl();
            GameManager.distance++;
           // Debug.Log(GameManager.distance);
        }
        Animate();
    }

    void FixedUpdate()
    {
        //Debug.Log(currCoroutine);
        if (alive)
        {
            GameManager.distance += 1;
            if (GameManager.distance % 100 == 0) GameManager.timeSpeed += speedInc;
            Time.timeScale = GameManager.timeSpeed;
        }
    }

    private void TryControl()
    {
        if (Time.timeScale == 0) return;
        if(Controls.GetInput(Controls.Direction.Up))
        {
            Move(Controls.Direction.Up);
        }
        if(Controls.GetInput(Controls.Direction.Down))
        {
            Move(Controls.Direction.Down);
        }
    }

    private void Animate()
    {
    }

    private void Move(Controls.Direction dir)
    {
        //Debug.Log(dir);

        if (currCoroutine != null) return;

        switch (dir)
        {

            case Controls.Direction.Up:
                if (_transform.position.y < maxHeigth)
                {   
                    currCoroutine = StartCoroutine(Moving(_transform.position + Vector3.up*incY));
                   //  _transform.position += Vector3.up * incY;
                }
                break;
            case Controls.Direction.Down:
                if (_transform.position.y > minHeigth)
                {
                    currCoroutine = StartCoroutine(Moving(_transform.position + Vector3.down * incY));
                    //_transform.position += Vector3.down * incY;
                }
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Lose();
            Destroy(collision.gameObject);
        }
    }

    private void Lose()
    {
        alive = false;
        Time.timeScale = 0;
        GameManager.SaveBestDist();
        deathMenu.SetActive(true);
    }


    private IEnumerator Moving(Vector3 endPos)
    {

        Vector3 dirVec = Vector3.Normalize(endPos - _transform.position);
        

        while(Vector2.Distance(_transform.position,endPos)> 0.01)
        {
            _transform.position += dirVec * speed;
            yield return new WaitForEndOfFrame();
        }


        currCoroutine = null;
        yield return null;
    }

}
