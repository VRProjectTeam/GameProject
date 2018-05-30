using UnityEngine;

public class UseXmlStorage : MonoBehaviour
{
    private static string fileName = Application.dataPath + "/Data";

    public static object XmlReadStorage(System.Type ty)
    {
        try
        {
            string strTemp = XmlStorage.LoadTextFile(fileName, false);

            object obj = XmlStorage.DeserializeObject(strTemp, ty);
            Debug.Log("反序列化成功");
            return obj;
        }
        catch
        {
            Debug.Log("反序列化失败");
            return null;
        }
    }

    public static void XmlWriteStorage(object obj)
    {
        try
        {
            string s = XmlStorage.SerializeObject(obj, obj.GetType());

            XmlStorage.CreateTextFile(fileName, s, false);
            Debug.Log("序列化成功");
        }
        catch
        {
            Debug.Log("序列化失败");
        }

    }
}
