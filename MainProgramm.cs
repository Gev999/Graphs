using System;

class MainProgramm
{
    static void Main()
    {
        int sizeOfArray, sizeOfLinks; int[] arrayU; int[] nums; int[,] arrayD; String[] arrayU2;

        AllFuncs.CreatingSizes(out sizeOfArray, out sizeOfLinks, out nums);

        AllFuncs.CreatingArrays(out arrayU, out arrayD, out arrayU2, sizeOfArray);

        AllFuncs.CreateArrayD(arrayD, sizeOfArray, sizeOfLinks);

        AllFuncs.ShowResults(nums, arrayU, arrayD, arrayU2, sizeOfArray);

        Console.ReadKey();
    }
}
