using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviewController : MonoBehaviour
{
    [SerializeField] Image previewImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open(Image newImage)
    {
        gameObject.SetActive(true);
        previewImage.sprite = newImage.sprite;
    }

    public void Close(GameObject preview)
    {
        preview.SetActive(false);
    }
}
