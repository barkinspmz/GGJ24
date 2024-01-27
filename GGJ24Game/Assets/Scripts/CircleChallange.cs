using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircleChallange : MonoBehaviour
{
    private Vector2 baseCurrentLocalScale;
    public bool canNarrow = true;
    [SerializeField] private float narrowCooldown;
    [SerializeField] private float narrowingTimeByTime;

    public bool isNarrowing = false;

    public static CircleChallange Instance;

    public bool eClicked = false;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        baseCurrentLocalScale = transform.localScale;
        StartCoroutine(CircleNarrowing());
        canNarrow = true;
    }

    
    public void ExpandCircle()
    {
        StartCoroutine(ExpandingCirle());
    }

    public IEnumerator ExpandingCirle()
    {
        while (transform.localScale.x >= baseCurrentLocalScale.x && transform.localScale.y >= baseCurrentLocalScale.y)
        {
            yield return new WaitForSeconds(0.05f);
            transform.localScale += new Vector3(0.1F, 0.1F);
        }
        transform.localScale = new Vector3(1, 1, 1);
    }

    IEnumerator CircleNarrowing()
    {
        while (canNarrow)
        {
            isNarrowing = false;
            yield return new WaitForSeconds(narrowCooldown);
            isNarrowing = true;
            while (transform.localScale.x > 0 && transform.localScale.y > 0 && !eClicked)
            {
                yield return new WaitForSeconds(narrowingTimeByTime);
                transform.localScale -= new Vector3(0.01F,0.01F);
            }
            eClicked = false;
        }
        yield return new WaitForSeconds(3f);
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
