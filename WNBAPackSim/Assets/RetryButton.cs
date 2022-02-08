using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    [SerializeField] private CardGen generator;
    private void Start()
    {
        StartCoroutine(Spin(false));
    }
    public void OnClick()
    {
        StartCoroutine(Spin(true));
        foreach(GameObject c in generator.cards)
        {
            c.GetComponent<Card>().TriggerFadeOut();
        }
    }
    IEnumerator Spin(bool reload)
    {
        Vector3 t = transform.rotation.eulerAngles;
        float goal = t.z - 180f;
        for (float rot = t.z; rot >= goal; rot -= 3f)
        {
            t.z = rot;
            transform.rotation = Quaternion.Euler(t);
            yield return new WaitForSeconds(.01f);
        }
        if (reload)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
