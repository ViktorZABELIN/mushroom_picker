using TMPro;
using UnityEngine;
using UnityEngine.UI;


public enum DeformationType
{
    Width,
    Height

}


public class GateScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    [SerializeField] Image topImage;
    [SerializeField] Image glassImage;

    [SerializeField] Color colorPositive;
    [SerializeField] Color colorNegative;

    [SerializeField] GameObject DownLable;
    [SerializeField] GameObject UpLable;

    [SerializeField] GameObject ExandLable;
    [SerializeField] GameObject ShrinckLable;

                

    public void UpdateVisual(DeformationType deformationType, int value)
    {

        string prefix = "";


        if (value > 0)
        {
            prefix = "+";
            SetColor(colorPositive);
        }
        else if (value == 0)
        {
            SetColor(Color.grey);
        }
        else
        {
            SetColor(colorNegative);
        }

        text.text = prefix + value.ToString();

        DownLable.SetActive(false);
        UpLable.SetActive(false);

        ExandLable.SetActive(false);
        ShrinckLable.SetActive(false);

        if (deformationType == DeformationType.Width)
        {
            if(value > 0)
            {
                ExandLable.SetActive(true);
            }
            else
            {
                ShrinckLable.SetActive(true);
            }
        }
        else if (deformationType == DeformationType.Height)
        {
            if (value > 0)
            {
                UpLable.SetActive(true);
            }
            else
            {
                DownLable.SetActive(true);
            }
        }


    }

    void SetColor(Color color)
    {
        topImage.color = color;
        glassImage.color = new Color(color.r, color.g, color.b, 0.5f);
    }



}
