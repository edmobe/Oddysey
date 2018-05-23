package com.src.sortingAlg;

import java.util.Scanner;

public class StringBubblesort {
	 Scanner reader = new Scanner(System.in);
     String tempStr;
     
     /**
      * Receives an array of n elements and sorts it
      * @param t1
      */
     public void sort(String[] t1) {

     for (int t = 0; t < t1.length - 1; t++) {
         for (int i= 0; i < t1.length - t -1; i++) {
             if(t1[i+1].compareTo(t1[i])<0) {
                 tempStr = t1[i];
                 t1[i] = t1[i + 1];
                 t1[i + 1] = tempStr;
             }
         }
     }
     for (int i = 0; i < t1.length; i++) {
         System.out.println(t1[i]);
     }
}


}
