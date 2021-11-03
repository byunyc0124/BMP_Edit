using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class simulation_select : MonoBehaviour
{
    public XRController controller = null;
    public float defaultLength = 3.0f;
    private LineRenderer lineRenderer = null;
    private bool isDowned = false; // 버튼 초기 상태

    [SerializeField] public ParticleSystem ring1;
    [SerializeField] public ParticleSystem ring2;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLength();
    }

    private void UpdateLength()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(0, CalculateEnd());
    }

    private Vector3 CalculateEnd()
    {
        RaycastHit hit = CreateForwardRaycast();
        Vector3 endPosition = DefaultEnd(defaultLength);
        if(hit.collider)
        {
            endPosition = hit.point;
        }
        return endPosition;
    }

    private RaycastHit CreateForwardRaycast()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, defaultLength);
        return hit;
    }

    private Vector3 DefaultEnd(float length)
    {
        return transform.position + (transform.forward * length);
    }

    
}
