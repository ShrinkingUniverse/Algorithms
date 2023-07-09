using System;
using System.Collections.Generic;

namespace ConsoleApp5
{
    class Program
    {
        public void LinkedListFun()
        {
            List<int> list1 = new List<int>() { 2, 57, 54, 45 };
            LinkedList<int> list2 = new LinkedList<int>(list1);
            list2.AddLast(76);
        }
        public void SelectionSearch(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int temp = array[i];
                int pos = i;
                for (int j = i; j < array.Length; j++)
                {
                    if (temp > array[j])
                    {
                        temp = array[j];
                        pos = j;
                    }
                }
                int val = array[i];
                array[i] = temp;
                array[pos] = val;
            }
        }

        public void InsertionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int pos = i;
                int temp = array[i];
                while (i > 0 && array[i] < array[i - 1])
                {
                    array[i] = array[i - 1];
                    i--;
                }
                array[pos] = temp;
            }
        }

        public void ShellSort(int[] array)
        {
            int gap = array.Length / 2;
            for (int step = gap; step > 0; step = step / 2)
            {
                if (step > 0)
                {
                    for (int j = step; j < array.Length; j++)
                    {
                        if (array[j - step] > array[j])
                        {
                            int temp = array[j];
                            array[j] = array[j - step];
                            array[j - step] = temp;
                        }
                    }
                }
            }
        }

        public void MergeSort(int[] array, int start, int finish)
        {
            if (start < finish)
            {
                int mid = (start + finish) / 2;
                MergeSort(array, start, mid);
                MergeSort(array, mid + 1, finish);
                Merge(array, start, mid, finish);
            }

        }
        private void Merge(int[] array, int start, int mid, int finish)
        {
            var i = start;
            var j = mid + 1;
            var k = start;
            int[] newArray = new int[finish + 1];
            while(i <= mid && j <= finish)
            {
                if(array[i] < array[j])
                {
                    newArray[k] = array[i];
                    i++;
                    k++;
                }
                else
                {
                    newArray[k] = array[j];
                    j++;
                    k++;
                }
            }
            while(i <= mid)
            {
                newArray[k] = array[i];
                i++;
                k++;
            }
            while (j <= finish)
            {
                newArray[k] = array[j];
                j++;
                k++;
            }
            for(int x = start; x <= finish; x++)
            {
                array[x] = newArray[x];
            }
        }
        public void QuickSort(int[] array, int start, int finish)
        {
            if (start < finish)
            {
                int pos = Divide(array, start, finish);
                QuickSort(array, start, pos - 1);
                QuickSort(array, pos + 1, finish);
            }
        }
        private int Divide(int[] array, int start, int finish)
        {
            int i = start+1;
            int j = finish;
            int pivot = array[start];
            do
            {
                while (array[i] < pivot && i < finish)
                {
                    i++;
                }
                while (array[j] > pivot && j > 0)
                {
                    j--;
                }
                if (array[i] > array[j])
                {
                    Swap(array, i, j);
                }
                Swap(array, start, j);
                return j;
            }
            while (i < j);
        }
        private void Swap(int[]array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        static void Main(string[] args)
        {
            int[] unsortedArray = new int[] { 250, 14, 48, 10, 98, 458, 156 };
            Program p = new Program();
            p.QuickSort(unsortedArray, 0, unsortedArray.Length-1);
            //p.QuickSort(unsortedArray, 0, unsortedArray.Length-1);
            foreach (int num in unsortedArray)
            {
                Console.WriteLine(num);
            }
            //Console.ReadKey();
        }
    }
}
