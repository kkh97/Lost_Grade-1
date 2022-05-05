using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    private int layerMask;

    // Start is called before the first frame update
    void Start()
    {
        layerMask = 1 << LayerMask.NameToLayer("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.SphereCast(transform.position + new Vector3(0, 0.9f, 0), 0.3f, Vector3.down, out RaycastHit hit, float.MaxValue, layerMask))
        {
            //������ ���� ���� �� ������ �������� ������ �а� ��
            if (hit.distance > 0.75f)
            {
                transform.Translate(new Vector3(0, -4.9f, 0) * Time.deltaTime);
            }
            else if (hit.distance < 0.45f)
            {
                transform.Translate(new Vector3(0, 4.9f, 0) * Time.deltaTime);
            }
        }
        else
        {
            transform.Translate(new Vector3(0, -4.9f, 0) * Time.deltaTime);
        }
    }
}
