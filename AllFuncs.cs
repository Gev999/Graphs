using System;

static class AllFuncs
{
    static public void CreatingSizes(out int sizeOfArray, out int sizeOfLinks, out int[] nums)
    {
        Console.Write("Nermuceq gagatneri qanaky : ");
        sizeOfArray = int.Parse(Console.ReadLine());
        Console.Write("Nermuceq kaperi qanaky : ");
        sizeOfLinks = int.Parse(Console.ReadLine());
        nums = new int[sizeOfArray];
        for (int i = 0; i < sizeOfArray - 1; nums[i++] = 0) ;
    }

    static public void CreatingArrays(out int[] arrayU, out int[,] arrayD, out String[] arrayU2, int size)
    {
        arrayU = new int[size];
        arrayU[0] = 0;
        for (int i = 1; i < size; arrayU[i++] = -1) ;
        arrayD = new int[size, size];
        arrayU2 = new String[size - 1];
        for (int i = 0; i < arrayU2.Length; i++)
            arrayU2[i] = "min(";
    }

    static public void CreateArrayD(int[,] arrayD, int sizeOfArray, int sizeOfLinks)
    {
        for (int i = 0; i < sizeOfArray; i++)
            for (int j = 0; j < sizeOfArray; arrayD[i, j++] = 0) ;
        Console.WriteLine("Nermuceq kapery ev chanaparhneri erkarutyunnery : ");
        for (int i = 0; i < sizeOfLinks; i++)
        {
            Console.WriteLine();
            Console.Write("elqayin gagat : ");
            int k = int.Parse(Console.ReadLine()) - 1;
            Console.Write("mutqayin gagat : ");
            int p = int.Parse(Console.ReadLine()) - 1;
            Console.Write("chanaparhi erkarutyuny : ");
            arrayD[k, p] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine();
        int count = 0;
        for (int i = 0; i < sizeOfArray; i++)
            for (int j = 0; j < sizeOfArray; j++)
            {
                if (arrayD[i, j] != 0)
                {
                    Console.Write("d[{0}, {1}] = {2}\t", i + 1, j + 1, arrayD[i, j]);
                    count++;
                }
                if (count == 7) { Console.WriteLine("\n"); count = 0; }
            }
        Console.WriteLine();
    }

    static public int MinOfRoads(int index, int size, int[,] arrD, int[] arrU, int[] nums, String[] str)
    {
        int min = int.MaxValue;
        for (int i = 0; i < size - 1; i++)
            if (arrD[i, index] != 0 && arrU[i] >= 0)
            {
                if ((arrU[i] + arrD[i, index]) < min)
                {
                    min = (arrU[i] + arrD[i, index]);
                    nums[index] = i + 1;
                }
                str[index - 1] += "U[" + (i + 1) + "] + " + "d[" + (i + 1) + "," + (index + 1) + "] : ";
            }
            else if (arrD[i, index] != 0 && arrU[i] < 0)
            {
                arrU[i] = MinOfRoads(i, size, arrD, arrU, nums, str);
                i--;
            }

        return min;
    }

    static public void ShowResults(int[] nums, int[] arrayU, int[,] arrayD, String[] arrayU2, int sizeOfArray)
    {
        Console.WriteLine("\n\nU[1] = 0");
        for (int i = 1; i < sizeOfArray; i++)
        {
            if (arrayU[i] < 0) arrayU[i] = AllFuncs.MinOfRoads(i, sizeOfArray, arrayD, arrayU, nums, arrayU2);
            Console.WriteLine("\nU[" + (i + 1) + "] = " + arrayU2[i - 1] + ") = " + arrayU[i] + " (" + nums[i] + ")");
        }
        Console.WriteLine();
        String str = "";
        int[] road = new int[nums.Length];
        for (int i = 0; i < nums.Length; road[i++] = 0) ;
        road[0] = nums[sizeOfArray - 1];
        int v;
        for (v = 1; road[v - 1] - 1 > 0; v++)
            road[v] = nums[road[v - 1] - 1];
        for (int i = v - 1; i >= 0; i--)
            str += "U[" + road[i] + "] -> ";
        Console.WriteLine("Amenakarch chanaparhy klini : ");
        Console.WriteLine(str + "U[" + sizeOfArray + "] = " + arrayU[sizeOfArray - 1]);
    }
}

