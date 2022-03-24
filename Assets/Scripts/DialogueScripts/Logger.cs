
using UnityEngine;

public class Logger : MonoBehaviour
{
   
   public void LogError( string MessageToLog, Object Sender , bool CanLog)
   {
        if (CanLog)
        {
            Debug.Log(MessageToLog + Sender.ToString());
        }
        
   }

}
