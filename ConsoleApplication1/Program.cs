using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//purpose of this program is to randomly fill an array with numbers and check to see if there is a majority element (number appears more than number of elements/2 times)

namespace A1Q2
{
    class Program
    {
        static int count = 0;//the number of times the element shows up
        static int valueL = 0, valueR =0; //the value that is being checked if it is the majority
        static void randomFill(int[] array)//fills the array with random numbers
        {
            Random rnd = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(1, 3);
            }
        }
        static int[] slice(int[] array, int start, int end)//creates the sliced array of half the size of the original array
        {
            int count = 0;//count of the elements of the new array
            int[] newArray = new int[end - start];//the new array 
            for (int i = start; i < end; i++)
            {
                newArray[count] = array[i];//filling the new array with the old elements
                count++;
            }
            return newArray;//returning the half array
        }

        static int findMajority(int[] array)
        {
            if (array.Length == 1)//if there is only one element
                return array[0];


            int[] right = slice(array, array.Length / 2, array.Length);//the array of the first half of the elements
            int[] left = slice(array, 0, array.Length / 2);//the array of the second half of the elements
            if (array.Length > 2)//if there is another split to happen
            {
                
                findMajority(left);
                findMajority(right);
            }
            else
            {
                valueL = findMajority(left);//if this is the element to be checked if it is the majority
                valueR = findMajority(right);
            }

            foreach (int i in array)
            {
                if (i == valueL)//determining if the majority element you are trying is actually a majority element
                    count++;
                if (count > array.Length / 2)//if the element is a majority element
                    return valueL;
            }
            foreach (int g in array)
            {
                if (g == valueR)//determining if the majority element you are trying is actually a majority element
                    count++;
                if (count > array.Length / 2)//if the element is a majority element
                    return valueR;
            }
            return -1;
        }

        static int Majority(int[] array)//determining which element is the majority for main
        {
            var element = findMajority(array);

            if (countElements(element, array) > array.Length / 2)//if the element appears more than n/2 times
                return element;
            else
                return -1;
        }

        static int countElements(int element, int[] array)//counting how many times an element appears
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (element == array[i])
                    count++;
            }
            return count;
        }


        static void Main(string[] args)
        {
            int[] array = new int[11]; //size of the array to be used to store the numbers
            Console.WriteLine("Here are the elements of the array:");
            randomFill(array);//randomly filling the array
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i].ToString().PadLeft(3));
            }
            Console.WriteLine();//printing the array of numbers
            var majority = Majority(array);//calling the majority function
            if (majority > 0)
                Console.WriteLine("There is a majority element of: " + majority);//if there is a majority element
            else 
                Console.WriteLine("There is no majority element");//if there is no majority element
            Console.WriteLine();
            Console.ReadKey();



        }
    }
}