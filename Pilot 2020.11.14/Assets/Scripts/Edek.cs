using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edek : MonoBehaviour
{
    public float range, speed;
    
    public GameObject target;
    private GameObject player, detector;
    private GameActions game;
    private EdgeCollider2D detectorCollider;
    private PolygonCollider2D ownBody;

    Vector2 highiestPosition, lowerPosition;

    [SerializeField] private LayerMask playerLayerMask;

    void Start()
    {
        highiestPosition = new Vector2(transform.position.x, transform.position.y + range);
        lowerPosition = new Vector2(transform.position.x, transform.position.y - range);

        game = gameObject.AddComponent<GameActions>();
        
        player = GameObject.Find("Player");
        detector = GameObject.Find("PlayerDetector");
        detectorCollider = detector.GetComponent<EdgeCollider2D>();
        ownBody = GetComponent<PolygonCollider2D>();
    }


    void FixedUpdate()
    {
        Movement();
        // PlayerInteractions();
    }

    private void Movement()
    {
        if (target)
        {
            Vector2 targetPosition = new Vector2(target.transform.position.x +0.5f, target.transform.position.y + 0.5f);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }

        if (target == null)
        {
            game.Float(gameObject, highiestPosition, lowerPosition, speed);
        }
    }

    private void PlayerInteractions()
    {
        if (ownBody.IsTouchingLayers(playerLayerMask))
        {
            game.Kill(target, true, true, false);
        }
    }

}
