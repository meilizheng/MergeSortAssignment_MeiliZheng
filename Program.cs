using System;
using System.Xml;

namespace MergeSortAssignment_MeiliZheng
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Creates a new integer array using the RandomArray method.
            int[] testArray = RandomArray();
            Console.Write("Original array: ");

            //Prints the original array.
            PrintArray(testArray);

            //Merge and sort the original array
            MergeSort(testArray);
            Console.WriteLine("\nSorted Array: ");

            //Print out the sorted array
            PrintArray(testArray);            
        }


        //Random Array Method
        static int[] RandomArray()
        {
            //Generates a random integer array of size 10 with values between 0 and 100.
            Random rand = new Random();
            int minNum = 0;
            int maxNum = 101;
            int size = 10;
            int[] arr;
            arr = new int[size];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(minNum, maxNum);
            }

            //return rand array
            return arr;
        }

        //MergeSort Method with int[] array premeter 
        static void MergeSort(int[] arr)
        {
            int arrLength = arr.Length;

            //Checks if the array is already sorted (length <= 1) and prints a message.
            if (arrLength <= 1)
            {
                Console.WriteLine("Array already sorted.");
                return;                
            }

            // Divides the array into left and right parts.
            int middleArray = arrLength / 2;
            
            int[] leftArray = new int[middleArray];
            
            int[] rightArray = new int[arrLength - middleArray];

            //use for loop to move the element in the arr to the left and right array
            for (int i = 0; i < middleArray; i++)
            {
                leftArray[i] = arr[i];
            }

            for (int i = middleArray; i < arrLength; i++)
            {
                rightArray[i - middleArray] = arr[i];
            }

            //Print out the left and right array.
            Console.WriteLine("Left Array:");
            PrintArray(leftArray);
            Console.WriteLine("Right Array:");
            PrintArray(rightArray);

            //Recursively calls MergeSort on left and right parts.
            Console.WriteLine("Sorting left array:");
            MergeSort(leftArray);
            Console.WriteLine("Sorting right array:");
            MergeSort(rightArray);

            Console.WriteLine("Merge Sorted Arrays:");
            //Merges and sorts the left and right arrays using the Merge method.
            Merge(arr, leftArray, rightArray);
        }


        //Merge and sort
        static void Merge(int[] arr, int[] leftArray, int[] rightArray)
        {
            int leftLength = leftArray.Length;
            int rightLength = rightArray.Length;

            int leftArrayIndex = 0;
            int rightArrayIndex = 0;
            int sortedArrayIndex = 0;

            //Merges and sorts two arrays (left and right) into a single array.
            while (leftArrayIndex < leftLength && rightArrayIndex < rightLength)
            {               
                if (leftArray[leftArrayIndex] <= rightArray[rightArrayIndex])
                {
                    arr[sortedArrayIndex] = leftArray[leftArrayIndex];
                    leftArrayIndex++;
                }
                
                else
                {
                    arr[sortedArrayIndex] = rightArray[rightArrayIndex];
                    rightArrayIndex++;
                }
                
                sortedArrayIndex++;
            }

            //Uses indices to traverse through left, right, and sorted arrays.
            while (leftArrayIndex < leftLength)
            {
                arr[sortedArrayIndex] = leftArray[leftArrayIndex];
                leftArrayIndex++;
                sortedArrayIndex++;
            }
            
            while (rightArrayIndex < rightLength)
            {
                arr[sortedArrayIndex] = rightArray[rightArrayIndex];
                rightArrayIndex++;
                sortedArrayIndex++;
            }
        }


        //Print out the arr.
        static void PrintArray(int[] arr)
        {
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}