int[,] NutonsBinomial1 (int power)
{
    int[,] array = new int [power+1,power+1];
    for (int i = 0; i < power +1; i++)
        for (int j = 0; j < power + 1; j++)
        {
            if (j==0) array[i,j] = 1;
            else array[i,j] = 0;
        }

    for (int i = 1; i < power + 1; i++)
    {
        for (int j = 1; j < i + 1; j++)
        {
            array[i,j] = array[i-1, j-1] + array[i-1,j];
        }
    }
    return array;
}

int[,] NutonsBinomial2 (int power)
{
    int rows = power + 1;
    int columns = (power + 1)*2 - 1;
    int[,] array = new int [rows,columns];

    for (int i = 0; i < rows; i++)
        for (int j = 0; j < columns; j++)
        {
            if ((i + j == power) || (j - i == power))
            {
                array[i,j] = 1;
            }
            else
                array[i,j] = 0;
        }
   
    if (power == 0 || power == 1)
        return array;
    
    for (int i = 2; i < rows; i++)
        for (int j = 1; j < columns-1; j++)
            array[i,j] = array[i-1,j-1] + array[i-1,j+1];
    
    return array;
}

void ShowPascalsTriangle (int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++) 
        {
            if (array[i,j]==0) Console.Write("    ");
            else 
            {
                if (array[i,j] < 10) Console.Write(" " + array[i,j] + "  ");
                else if (array[i,j] < 100) Console.Write(" " + array[i,j] + " ");
                else Console.Write(array[i,j] + " ");
            }
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}




Console.Write("Введите степень: " );
int power = Convert.ToInt32(Console.ReadLine());
ShowPascalsTriangle(NutonsBinomial2(power));
