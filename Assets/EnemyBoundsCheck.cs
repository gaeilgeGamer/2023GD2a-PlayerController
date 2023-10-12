using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoundsCheck : MonoBehaviour
{
    [Header("Fall Check")]
    [SerializeField] private float minY = -10f;

    [Header("Off Screen Check")]
    [Tooltip("Extra space before enemy is considered off screen")]
    [SerializeField] private float screenBuffer = 1.0f;

    private Camera mainCamera;
    private EnemyController enemyController;
    // Start is called before the first frame update
    void Awake()
    {
        mainCamera = Camera.main;
        enemyController = GetComponent<EnemyController>();

        if(!enemyController)
        {
            Debug.LogError("EnemyBoundsCheck is missing EnemyController on the same GameObject", gameObject);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if(transform.position.y < minY)
        {
            enemyController.Die();
            return;
        }

    Vector3 enemyScreenPos = mainCamera.WorldToViewportPoint(transform.position);
    if(enemyScreenPos.x < -screenBuffer || enemyScreenPos.x>1+screenBuffer||
    enemyScreenPos.y<-screenBuffer|| enemyScreenPos.y> 1+screenBuffer)
    {
        enemyController.Die();
    }
    }
}
