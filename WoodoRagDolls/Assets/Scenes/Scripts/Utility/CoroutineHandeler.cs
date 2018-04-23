using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineHandeler : MonoBehaviour
{

    public static CoroutineHandeler instance;

    private void Awake()
    {
        instance = this;

    }
    void Start()
    {

    }

    // Update is called once per frame
    public IEnumerator RotateMiniBoss(Quaternion targetRotation, Transform transform, float speed)
    {

        float counter = 0;
        while (counter < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, counter);
            yield return null;
            counter = 1f* Time.deltaTime * speed;
        }

    }
}
