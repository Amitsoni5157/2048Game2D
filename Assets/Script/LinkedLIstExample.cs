using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedLIstExample : MonoBehaviour
{

    public LinkedList<int> linkList = new LinkedList<int>(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
    void Start()
    {
        /* Reverse LinkedList foreach (var item in linkList)
         {
             Debug.Log(item + " On initial Level");
         }

         var head = linkList.First;
         while (head.Next != null)
         {
             var next = head.Next;
             linkList.Remove(next);
             linkList.AddFirst(next.Value);
         }
         foreach (var item in linkList)
         {
             Debug.Log(item + " On Final Level");
         }*/
        // RevrseString("Hello");
    }

    /* public void RevrseString(string input)
     {
         char[] chr = input.ToCharArray();

         for (int i = 0, j = chr.Length -1; i < j; i++,j--)
         {
             char temp = chr[i];
             chr[i] = chr[j];
             chr[j] = temp;
         }

         string rev = new string(chr);
         Debug.Log(rev.ToString()+" : Reversed");

     }*/
    public float moveSpeed = 2.0f;

    private float timer = 0f;

    void Update()
    {
        // Increment the timer based on time.deltaTime
        timer += Time.deltaTime;

        // Calculate the position based on a square pattern
        float x = Mathf.Cos(timer * moveSpeed);
        float y = Mathf.Sin(timer * moveSpeed);

        // Set the object's position
        transform.position = new Vector3(x, y, 0f);
    }
}
