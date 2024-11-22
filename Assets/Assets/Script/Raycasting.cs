using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Raycasting : MonoBehaviour
{
    public GameObjectEvent onHit;

    [SerializeField] GameObject formularUI;
    [SerializeField] GameObject Phone;

    private int Power = 3;

    private void Start()
    {

    }
    void Update()
    {
        Debug.DrawRay(transform.position, Camera.main.transform.forward * 100, Color.red);
    }
    public void Raycas()
    {
        int layerMask = 1 << 8;

        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            if (hit.collider != null)
            {
                if (Phone.activeSelf == true)
                {
                    Power -= 1;
                    onHit.Invoke(hit.collider.gameObject);
                }

            }
        }
    }
    public int GetPower()
    {
        return Power;
    }
}