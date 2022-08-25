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

    void Start()
    {
        // 画面の左下と右上の座標を取得
        min = Camera.main.ViewportToWorldPoint(Vector2.zero);
        max = Camera.main.ViewportToWorldPoint(Vector2.one);

        // 自身のスプライトの幅を取得
        width = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // 左矢印が押された時
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // 基準がセンターなので、画面の端の座標から自身のスプライトの幅/2を足す
            if (transform.position.x > min.x + width / 2)
            {
                transform.Translate(-0.1f, 0, 0);
            }
        }

        // 右矢印が押された時
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // 基準がセンターなので、画面の端の座標から自身のスプライトの幅/2を引く
            if (transform.position.x < max.x - width / 2)
            {
                transform.Translate(0.1f, 0, 0);
            }

        }

        // スペースが押された時
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }
}
