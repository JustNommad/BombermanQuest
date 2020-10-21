using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float timer = 3.0f;
    void Start()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(timer);
        Destroy(this);
        var v = new Vector2(transform.position.x, transform.position.y);
        var colliders = Physics2D.OverlapCircleAll(v, 2.0f);
            foreach (var c in colliders)
            {
                if(c.CompareTag("Dist"))
                    Destroy(c.gameObject);
                if(c.CompareTag("Player"))
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
    }
}
