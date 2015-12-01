using UnityEngine;
using System.IO;

public static class ScriptErrorLogging{

    public static void logError(string errorText, bool clearLog = false)
    {
#if Unity_Editor
        if(clearLog)
        {
            Debug.Log("wiping logFile.txt");
        }
        Debug.Log(errorText);
#else
        if(clearLog)
        {
            File.WriteAllText(Application.dataPath + "/logFile.txt", errorText);
        }
        else
        {
            using(StreamWriter file = new StreamWriter(Application.dataPath + "logFile.txt"))
            {
                file.WriteLine("[ERROR]: " + errorText);
            }
        }
#endif
    }
}
