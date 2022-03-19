void InsertionSort(int[] arr)
{
    int n = arr.Length;
    int key, j;


    for (int i = 1; i < n; i++)
    {
        key = arr[i];
        j = i - 1;

        while (j >= 0 && arr[j] > key)
        {
            arr[j + 1] = arr[j]; 
            j--;
        }

        arr[j + 1] = key;
    }
}

void InsertionSortDesc(int[] arr)
{
    int n = arr.Length;
    int key, j;


    for (int i = 1; i < n; i++)
    {
        key = arr[i];
        j = i - 1;

        while (j >= 0 && arr[j] < key)
        {
            arr[j + 1] = arr[j];
            j--;
        }

        arr[j + 1] = key;
    }
}


int[] arr = new int[] { 31, 41, 59, 26, 41, 58 };
InsertionSort(arr);
Console.WriteLine(String.Join(' ', arr));
InsertionSortDesc(arr);
Console.WriteLine(String.Join(' ', arr));
