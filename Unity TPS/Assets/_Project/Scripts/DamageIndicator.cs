using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageIndicator : MonoBehaviour
{
    public Text damageIndicator;
    private float lifeTime = 0.6f;
    private float minDist = 1.5f;
    private float maxDist = 3f;
    private Vector3 initialPos;
    private Vector3 targetPos;
    private float timer;

    private void Start()
    {
        transform.LookAt(2 * transform.position - Camera.main.transform.position);

        float direction = Random.rotation.eulerAngles.z;
        initialPos = transform.position;
        float dist = Random.Range(minDist, maxDist);
        targetPos = initialPos + (Quaternion.Euler(0, 0, direction) * new Vector3(dist, dist, 0));
        transform.localScale = Vector3.zero;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        float fraction = lifeTime / 2f;

        if (timer >= lifeTime)
        {
            Destroy(gameObject);
        } else if (timer >= fraction)
        {
            damageIndicator.color = Color.Lerp(damageIndicator.color, Color.clear, (timer - fraction) / (lifeTime - fraction));
        }

        transform.position = Vector3.Lerp(initialPos, targetPos, Mathf.Sin(timer / lifeTime));
        transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, Mathf.Sin(timer / lifeTime));
    }

    public void SetDamageIndicator(float damage)
    {
        damageIndicator.text = damage.ToString();
    }
}
