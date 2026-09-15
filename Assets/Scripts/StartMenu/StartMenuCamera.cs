using UnityEngine;

public class StartMenuCamera : MonoBehaviour
{
    [SerializeField] private GameObject[] CameraPoints;
    private int _currentPosition=0;
    private Vector2 _nextPosition;

    [SerializeField] private float speed=5f;

    private void Start()
    {
        transform.position=CameraPoints[0].transform.position;
        NextPoint();
    }

    private void Update()
    {
        VerifyLocation();
        Vector2 direction = (_nextPosition - (Vector2)transform.position).normalized;
        transform.Translate(direction.x*Time.deltaTime*speed,direction.y*Time.deltaTime*speed,0);
        transform.position=new Vector3(transform.position.x,transform.position.y,-10);
    }

    private void VerifyLocation()
    {
        if (((Vector2)transform.position-_nextPosition).magnitude<0.5f)
        {
            NextPoint();
        }
    }

    private void NextPoint()
    {
        _currentPosition++;
        if (_currentPosition>=CameraPoints.Length)
            _currentPosition=0;

        _nextPosition = CameraPoints[_currentPosition].transform.position;
    }
}
