using UnityEngine;
using UnityEngine.UI;

public class PreviewController : MonoBehaviour
{
    [SerializeField] Image previewImage;

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
