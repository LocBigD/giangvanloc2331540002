using System.Collections;
using UnityEngine;

public class Coin_VoThienPhuoc : MonoBehaviour
{
    [Header("Coin Settings")]
    [SerializeField] private float moveUpSpeed = 3f;   
    [SerializeField] private float lifeTime = 0.5f; 
    private const int COIN_VALUE = 8;                  // 1 + số cuối MSSV

    private void Start()
    {
        StartCoroutine(AnimateAndCollect());
    }

    private IEnumerator AnimateAndCollect()
    {
        Vector3 target = transform.position + Vector3.up * 1.5f;
        while (transform.position.y < target.y)
        {
            transform.position += Vector3.up * moveUpSpeed * Time.deltaTime;
            yield return null;
        }

        /*Cộng điểm */
        GameManager gm = null;

        var instProperty = typeof(GameManager).GetProperty("Instance");
        if (instProperty != null)
            gm = instProperty.GetValue(null) as GameManager;

        if (gm == null)
            gm = FindObjectOfType<GameManager>();

        if (gm != null)
            gm.SendMessage("AddScore", COIN_VALUE, SendMessageOptions.DontRequireReceiver);
        else
            Debug.LogError("Không tìm thấy GameManager để cộng điểm!");

        /*  Đợi thêm lifeTime rồi huỷ coin */
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
