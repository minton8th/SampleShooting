using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public GameObject bulletPrefab;

    // 映っている画面の端のワールド座標
    Vector2 min;
    Vector2 max;

    // 自身の幅
    float width;

    // Start is called before the first frame update
    void Start()
    {
        // 画面の左下と右上の座標を取得
        min = Camera.main.ViewportToWorldPoint(Vector2.zero);
        max = Camera.main.ViewportToWorldPoint(Vector2.one);

        // 自身のスプライトの幅を取得
        width = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > min.x + width / 2)
            {
                transform.Translate(-0.1f, 0, 0);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < max.x - width / 2)
            {
                transform.Translate(0.1f, 0, 0);
            }

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }
}
