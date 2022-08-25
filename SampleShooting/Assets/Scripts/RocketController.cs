using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public GameObject bulletPrefab;

    // 映っている画面の端のワールド座標
    private Vector2 displayMin;
    private Vector2 displayMax;

    // 自身の幅
    private float spriteWidth;

    // 境界値
    private float limitMin;
    private float limitMax;

    void Start()
    {
        // 画面の左下と右上の座標を取得
        displayMin = Camera.main.ViewportToWorldPoint(Vector2.zero);
        displayMax = Camera.main.ViewportToWorldPoint(Vector2.one);

        // 自身のスプライトの幅を取得
        spriteWidth = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;

        // 境界値を設定
        limitMin = displayMin.x + spriteWidth / 2;
        limitMax = displayMax.x - spriteWidth / 2;
    }

    void Update()
    {
        // 左矢印が押された時
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // 基準がセンターなので、画面の端の座標から自身のスプライトの幅/2を足す
            if (transform.position.x > limitMin)
            {
                transform.Translate(-0.1f, 0, 0);
            }
        }

        // 右矢印が押された時
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // 基準がセンターなので、画面の端の座標から自身のスプライトの幅/2を引く
            if (transform.position.x < limitMax)
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
