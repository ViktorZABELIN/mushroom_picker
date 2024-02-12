using System.Runtime.InteropServices;
using UnityEngine;

public class Language : MonoBehaviour
{
    public static string CurrentLanguage = "";

    public static Language Inctance;

    [DllImport("__Internal")]
    private static extern string GetLang();


    private void Awake()
    {
        if (Inctance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Inctance = this;
            CurrentLanguage = GetLang();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
