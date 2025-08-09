using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class MovementTrail : MonoBehaviour
{
    public int maxPoints = 20;
    public float recordInterval = 0.1f;
    public float yOffset = 0.5f;

    private List<Vector3> points = new List<Vector3>();
    private float timer;
    private LineRenderer line;

    void Awake()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 0;
        line.widthMultiplier = 0.05f;
        line.material = new Material(Shader.Find("Sprites/Default"));
        line.startColor = Color.yellow;
        line.endColor = Color.yellow;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = recordInterval;
            RecordPosition();
        }

        line.positionCount = points.Count;
        line.SetPositions(points.ToArray());
    }

    private void RecordPosition()
    {
        points.Add(transform.position + Vector3.up * yOffset);

        if (points.Count > maxPoints)
            points.RemoveAt(0);
    }
}
