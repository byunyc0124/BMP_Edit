using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket_ver_feed : MonoBehaviour
{
    public ParticleSystem part;
    MeshRenderer mesh;
    Material mat;
    private Animator cow1 = null;

    void Start()
    {
        part = GetComponent<ParticleSystem>();
        mesh = GetComponent<MeshRenderer>();
        mat = mesh.material;
        cow1 = GameObject.Find("Cow (1)").GetComponent<Animator>();
    }

    private void Update()
    {

    }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("충돌감지");
        if (other.tag == "Water")
        {
            cow1.SetBool("Eat", true);
            Invoke("ColorChange", 3.0f);
        }
    }

    public void ColorChange()
    {
        if (mat.color != new Color(51 / 255f, 0 / 255f, 0 / 255f, 255 / 255f))
        {
            mat.color = new Color(51 / 255f, 0 / 255f, 0 / 255f, 255 / 255f);
            Stage5GrabInteraction.cnt++;
        }
    }
}
