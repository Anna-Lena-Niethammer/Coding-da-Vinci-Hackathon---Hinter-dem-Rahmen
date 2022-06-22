using UnityEngine;

public class GalleryMoveAnimation : MonoBehaviour
{
    public bool isMoving;
    
    private static float moveSpeed = 1f;
    
    private static float fadeSpeed = 1f;

    private Vector3 _targetDestination;

    private float _targetAlphaTransparency;

    private Renderer _rendererComponent;

    // Start is called before the first frame update
    void Start()
    {
        SetTargetDestination(gameObject.transform.localPosition);
     
        _rendererComponent = gameObject.GetComponent<Renderer>();
        SetTargetAlpha(_rendererComponent.material.color.a);
    }

    // Update is called once per frame
    void Update()
    {
        if (_targetDestination != gameObject.transform.localPosition)
        {
            Move();
        }
        else
        {
            isMoving = false;
        }

        if (_targetAlphaTransparency != _rendererComponent.material.color.a)
        {
            ChangeTransparency();
        }

        if (_targetAlphaTransparency == 0 && _rendererComponent.material.color.a == 0 && !isMoving)
        {
            gameObject.SetActive(false);
        }
    }

    public void SetTargetDestination(Vector3 target)
    {
        gameObject.SetActive(true);
        _targetDestination = target;
        isMoving = true;
    }

    public void SetTargetAlpha(float alpha)
    {
        _targetAlphaTransparency = alpha;
    }
    
    private void Move()
    {
        float movement = moveSpeed * Time.deltaTime;

        Vector3 oldPosition = gameObject.transform.localPosition;
        Vector3 newPosition = Vector3.MoveTowards(oldPosition, _targetDestination, movement);

        gameObject.transform.localPosition = newPosition;
    }

    private void ChangeTransparency()
    {
        float fade = fadeSpeed * Time.deltaTime;

        Color newColor = _rendererComponent.material.color;
        float oldAlpha = newColor.a;
        if (oldAlpha < _targetAlphaTransparency)
        {
            float newAlpha = oldAlpha + fade;
            newColor.a = newAlpha > _targetAlphaTransparency ? _targetAlphaTransparency : newAlpha;
        }
        else
        {
            float newAlpha = oldAlpha - fade;
            newColor.a = newAlpha < _targetAlphaTransparency ? _targetAlphaTransparency : newAlpha;
        }

        _rendererComponent.material.color = newColor;
    }
}
