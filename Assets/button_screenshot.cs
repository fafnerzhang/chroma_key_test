using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class button_screenshot : MonoBehaviour {
    
    void Start()
    {
        Debug.Log(System.DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss"));
    }
    public void TakeScreenshot ()
    {
        StartCoroutine(TakeShot());
    }
    IEnumerator TakeShot()      //截图
    {
        string prefix = "ScreenShots";
        int scale = 1;
        bool useReadPixels = false;
        Texture2D texture;
        string date = System.DateTime.Now.ToString("yyyyMMddHHmmss");       //获得系统当前日期
        int screenWidth = Screen.width;                                     //获得屏幕宽度
        int screenHeight = Screen.height;                                   //获得屏幕高度

        Rect screenRect = new Rect(0, 0, screenWidth, screenHeight);        //定义一个屏幕大小的juxing，这里指的是Game视图的运行窗口屏幕

        if (useReadPixels)
        {
            yield return new WaitForEndOfFrame();                           //等待所有的摄像机和GUI被渲染完成后，在该帧显示在屏幕之前。
            texture = new Texture2D(screenWidth, screenHeight, TextureFormat.RGB24, false);     //创建一个RGB24格式的屏幕大小的图片
            texture.ReadPixels(screenRect, 0, 0);                           //读取屏幕大小的像素
            texture.Apply();                                                //更新贴图的mipmap，想具体了解的同学可以查官方文档，Mipmap是一种贴图渲染的常用技术，想了解的请自己搜索，在这里就不赘述了
            byte[] bytes = texture.EncodeToPNG();                           //将读到的贴图转换成byte数组格式
            Destroy(texture);                                               //摧毁贴图


            File.WriteAllBytes(Path.GetDirectoryName(Application.persistentDataPath) + Path.DirectorySeparatorChar + prefix + date + ".png", bytes);      //创建一个新文件，在其中写入指定的字节数组，然后关闭该文件，如果目标文件已存在则覆盖该文件
            Debug.Log("ScreenShots" + prefix + date + ".png finshed");          //打印信息

        }
        else
        {
            ScreenCapture.CaptureScreenshot(prefix + date + ".png", scale);           //调用系统自带的截图函数   
            Debug.Log(scale + "ScreenShots" + prefix + date + ".png finshed");       //打印信息
        }


    }

}

	
