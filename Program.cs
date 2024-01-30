using System;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Merge Sort Implementation in C#");
        // Array initialization and method calls will go here

        int[] array = { 12, 11, 13, 5, 6, 7 };

        Console.WriteLine("Original Array:");
        PrintArray(array);

        MergeSort(array, 0, array.Length - 1);

        Console.WriteLine("Sorted Array:");
        PrintArray(array);
    }

    public static void MergeSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            
            int middle = (left + right) / 2; // middle is the spot center spot of the array and make the left side the left and right side the right

            // I realized I keep getting confused because I think middle is the actual number /2 when it is acutally just
            // the placeholder like the card is flipped around. If the array it (5,7,4,2)
            // the array being sorted would be (0,1,2,3)
            // 0 + 3/ 2 = 1
            // so 0,1 is the left side and 2,3 is the right side.
            
            MergeSort(array, left, middle); // now we flip the cards over and sort the numbers
            MergeSort(array, middle + 1, right); // the middle number usually goes to the left side so the middle +1 is on the right side

           
            Merge(array, left, middle, right); // now we combine the left sorted side and the right sorted side to make one sorted side
        }
    }

   public static void Merge(int[] array, int left, int middle, int right)
    {
        

        int n1 = middle - left + 1;  //the left mini array
        int n2 = right - middle; // the right mini array

        
        int[] leftArray = new int[n1]; // the temporary left mini array 
        int[] rightArray = new int[n2]; //  the temporary Right mini array 

        // Copy data to temp arrays leftArray[] and rightArray[]
        for (int i = 0; i < n1; i++)
            leftArray[i] = array[left + i]; // left + I to represent the number of times it has gone threw the loop
        for (int j = 0; j < n2; j++)
            rightArray[j] = array[middle + 1 + j];  // Right + J to represent the number of times it has gone threw the loop

        int k = left; // K is also left
        int x = 0, y = 0; // x and y are 0

        // Merge the temp arrays back into array[left..right]
        while (x < n1 && y < n2)
        {
            if (leftArray[x] <= rightArray[y]) // check if left mini array bigger or equal to the right mini array
            {
                array[k] = leftArray[x]; // if it is merge left array to the k merge array
                x++;
            }
            else
            {
                array[k] = rightArray[y]; // else make the right array the k merge array.
                y++;
            }
            k++;
            // X is the left array in the mini array, Y is the right mini array, and K is the merge of both arrays.
            // making something the K array makes it the New left array AKA the Smallest number

        }

        // Copy the remaining elements of leftArray[], if there are any
        while (x < n1)
        {
            array[k] = leftArray[x];
            x++;
            k++;
        }

        // Copy the remaining elements of rightArray[], if there are any
        while (y < n2)
        {
            array[k] = rightArray[y];
            y++;
            k++;
        }
    }
    public static void PrintArray(int[] array)
    {
        foreach (var item in array)// for each item in the array print the number with a space in between them.
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

}
