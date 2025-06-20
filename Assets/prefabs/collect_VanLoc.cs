using UnityEngine;

public class Collectible_VoThienPhuoc : MonoBehaviour
{
   
    private const string STUDENT_ID = "233540027";          
    private readonly int scoreValue = 1 + (STUDENT_ID[^1] - '0'); 

  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        AddScoreToGameManager();
        Destroy(gameObject);   
    }

    
    private void AddScoreToGameManager()
    {
        GameManager gm = null;

#if UNITY_2023_1_OR_NEWER
        gm = FindAnyObjectByType<GameManager>();          // nhanh nhất Unity 2023+
#else
        gm = FindObjectOfType<GameManager>();             // Unity cũ hơn
#endif

        if (gm != null)
        {
            gm.AddScore(scoreValue);
        }
        else
        {
            Debug.LogError("Không tìm thấy GameManager trong Scene!");
        }
    }
}
