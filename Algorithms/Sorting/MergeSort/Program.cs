void Merge(int[] arr, int l, int m, int r)
{
    int n1 = m - l + 1;
    int n2 = r - m;

    int[] leftArr = new int[n1];
    int[] rightArr = new int[n2];

    int i, j;

    for (i = 0; i < n1; i++)
    {
        leftArr[i] = arr[l + i];
    }

    for (j = 0; j < n2; j++)
    {
        rightArr[j] = arr[m + 1 + j];
    }

    i = 0;
    j = 0;

    int k = l;

    while (i < n1 && j < n2)
    {
        if (leftArr[i] <= rightArr[j])
        {
            arr[k] = leftArr[i];
            i++;
        }
        else
        {
            arr[k] = rightArr[j];
            j++;
        }

        k++;
    }

    while (i < n1)
    {
        arr[k] = leftArr[i];
        i++;
        k++;
    }

    while (j < n2)
    {
        arr[k] = rightArr[j];
        j++;
        k++;
    }

}

void MergeSort(int[] arr, int left, int right)
{
    if (left < right)
    {
        int middle = left + (right - left) / 2;

        MergeSort(arr, left, middle);
        MergeSort(arr, middle + 1, right);

        Merge(arr, left, middle, right);
    }
}

void PrintArray(int[] arr)
{
    Console.WriteLine(String.Join(", ", arr));
}

int[] arr = new int[] { 2, 4, 1, 9, 7, 3, 5, 12, 3, 6 };
MergeSort(arr, 0, arr.Length - 1);
PrintArray(arr);

