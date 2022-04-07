using System.Diagnostics;
using System;
using UnityEngine;


namespace Name
{
    public class Class1 : MonoBehaviour {
        
        public static string ak = "ak is my best friends , the other is not REPLACE ";

       private void Start() {

        UnityEngine.Debug.Log("11111");     
       }

       public static string getAk(){

           return ak;
       }
    }
}
