using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeScript : MonoBehaviour
{
    [SerializeField] private float _moveAmount = 0.5F; //Camera's shake amount
    [SerializeField] private int _cycleCount = 5; //How many times will camera shake
    [SerializeField] private float _interval = 0.025F; //Duration between shakes

    [ContextMenu("Camera Shake")] //Let us run the function from inspector
    private void CameraShake()
    {
        StartCoroutine(CameraShakeRoutine(_moveAmount,_cycleCount,_interval));
    }

    IEnumerator CameraShakeRoutine(float moveAmount, int cycleCount, float interval)
    {
        Vector3 lastPos = transform.position; //Camera's position before shaking
        Vector3 pos;

        for (int i = 0; i < cycleCount; i++)
        {
            float x = Random.Range(-moveAmount,moveAmount);
            float y = Random.Range(-moveAmount,moveAmount);
            pos = transform.position;
            pos.x += x;
            pos.y += y;
            transform.position = pos;
            yield return new WaitForSeconds(interval);
            pos = transform.position;
            pos.x -= x;
            pos.y -= y;
            transform.position = pos;
            yield return new WaitForSeconds(_interval);
        }

        transform.position = lastPos;
    }
}
