using System.Drawing;

char[,] board = new char[10, 10];
int Size = 10;
var SingleDeckerFlag = false;
var DoubleDeckerFlag = false;
var ThreeDeckerFlag = false;
var FourDeckerFlag = false;


Menu();
void Menu()
{
    InitializeBoard();
    Board();

    while (!SingleDeckerFlag || !DoubleDeckerFlag || !ThreeDeckerFlag || !FourDeckerFlag)
    {

        if (SingleDeckerFlag && DoubleDeckerFlag && ThreeDeckerFlag)
        {
            Console.WriteLine("Выберете палубность корабля, которые хотите расставить (4):");
        }
        else if (SingleDeckerFlag && DoubleDeckerFlag && FourDeckerFlag)
        {
            Console.WriteLine("Выберете палубность корабля, которые хотите расставить (3):");
        }
        else if (SingleDeckerFlag && ThreeDeckerFlag && FourDeckerFlag)
        {
            Console.WriteLine("Выберете палубность корабля, которые хотите расставить (2):");
        }
        else if (DoubleDeckerFlag && ThreeDeckerFlag && FourDeckerFlag)
        {
            Console.WriteLine("Выберете палубность корабля, которые хотите расставить (1):");
        }
        else if (SingleDeckerFlag && DoubleDeckerFlag)
        {
            Console.WriteLine("Выберете палубность корабля, которые хотите расставить (3, 4):");
        }
        else if (SingleDeckerFlag && ThreeDeckerFlag)
        {
            Console.WriteLine("Выберете палубность корабля, которые хотите расставить (2, 4):");
        }
        else if (SingleDeckerFlag && FourDeckerFlag)
        {
            Console.WriteLine("Выберете палубность корабля, которые хотите расставить (2, 3):");
        }
        else if (DoubleDeckerFlag && ThreeDeckerFlag)
        {
            Console.WriteLine("Выберете палубность корабля, которые хотите расставить (1, 4):");
        }
        else if (DoubleDeckerFlag && FourDeckerFlag)
        {
            Console.WriteLine("Выберете палубность корабля, которые хотите расставить (1, 3):");
        }
        else if (ThreeDeckerFlag && FourDeckerFlag)
        {
            Console.WriteLine("Выберете палубность корабля, которые хотите расставить (1, 2):");
        }
        else if (SingleDeckerFlag)
        {
            Console.WriteLine("Выберете палубность корабля, которые хотите расставить (2, 3, 4):");
        }
        else if (DoubleDeckerFlag)
        {
            Console.WriteLine("Выберете палубность корабля, которые хотите расставить (1, 3, 4):");
        }
        else if (ThreeDeckerFlag)
        {
            Console.WriteLine("Выберете палубность корабля, которые хотите расставить (1, 2, 4):");
        }
        else if (FourDeckerFlag)
        {
            Console.WriteLine("Выберете палубность корабля, которые хотите расставить (1, 2, 3):");
        }

        else
        {
            Console.WriteLine("Выберете палубность корабля, которые хотите расставить (1 - 4):");
            Console.WriteLine("однопалубный корабль - 4шт.");
            Console.WriteLine("двухпалубный корабль - 3шт.");
            Console.WriteLine("трехпалубный корабль - 2шт.");
            Console.WriteLine("четырехпалубный корабль - 1шт.");
        }

        int count;
        Console.Write("count = ");
        while (!Int32.TryParse(Console.ReadLine(), out count) || count < 1 || count > 4)
        {
            Console.WriteLine("Не верный ввод.Введите число:");
            Console.Write("count = ");
        }

        switch (count)
        {
            case 1:
                if (!SingleDeckerFlag)
                {
                    SingleDeckShips();
                }
                else
                    Console.WriteLine("Такой корабль уже расставлен.");
                break;
            case 2:
                if (!DoubleDeckerFlag)
                {
                    DoubleDeckerShips();
                }
                else
                    Console.WriteLine("Такой корабль уже расставлен.");
                break;
            case 3:
                if (!ThreeDeckerFlag)
                {
                    ThreeDeckerShips();
                }
                else
                    Console.WriteLine("Такой корабль уже расставлен.");
                break;
            case 4:
                if (!FourDeckerFlag)
                {
                    FourDeckerShips();
                }
                else
                    Console.WriteLine("Такой корабль уже расставлен.");
                break;
        }
    }
}


//SingleDeckShips();
//DoubleDeckerShips();
//ThreeDeckerShips();
//FourDeckerShips();

void InitializeBoard()
{
    for (int i = 0; i < Size; i++)
    {
        for (int j = 0; j < Size; j++)
        {
            board[i, j] = '.';
        }
    }
}

void Board()
{
    Console.WriteLine("   12345678910");
    for (int i = 0; i < Size - 1; i++)
    {
        Console.Write($"{i + 1}  ");
        for (int j = 0; j < Size; j++)
        {
            //Console.Write(board[i, j]);
            if (board[i, j] == 'X')
                Console.Write('X');
            else
                Console.Write('.');
        }
        Console.WriteLine();
    }
    for (int i = 9; i < 10; i++)
    {
        Console.Write($"{i + 1} ");
        for (int j = 0; j < Size; j++)
        {
            if (board[i, j] == 'X')
                Console.Write('X');
            else
                Console.Write('.');
        }
        Console.WriteLine();
    }
}


void VvodCoordinates(int i, out int x, out int y, string Decker)
{
    Console.WriteLine($"Введите координату X {i + 1}-го {Decker} корабля:"); ;
    if (!int.TryParse(Console.ReadLine(), out x))
    {
        throw new Exception("Введенная строка не является числом.");
    }
    else x -= 1;
    Console.WriteLine($"Введите координату Y {i + 1}-го {Decker} корабля:"); ;
    if (!int.TryParse(Console.ReadLine(), out y))
    {
        throw new Exception("Введенная строка не является числом.");
    }
    else y -= 1;
}

string Direction()
{
    Console.WriteLine("Выберите расположение корабля (вертикальное - v, горизонтальное - h):");
    var direction = Console.ReadLine();
    while (!(direction == "v" || direction == "h"))
    {
        Console.WriteLine("Не верный ввод.Введите расположение корабля (вертикальное - v, горизонтальное - h):");
        direction = Console.ReadLine();
    }
    return direction;
}

void IsOccupiedCellsVer(int x,int y, int countDecker)
{
    for (var i = x - 1; i <= x + countDecker; i++)
        for (var j = y - 1; j <= y + 1; j++)
        {
            if (i < 0 || j < 0 || i >= Size  || j >= Size) continue;
            if (board[i, j] != 'X')
                board[i, j] = '1';
        }
}
void IsOccupiedCellsHor(int x, int y, int countDecker)
{
    for (var i = x - 1; i <= x + 1; i++)
        for (var j = y - 1; j <= y + countDecker; j++)
        {
            if (i < 0 || j < 0 || i >= Size || j >= Size) continue;
            if (board[i, j] != 'X')
                board[i, j] = '1';
        }
}




bool IsValidPlaceVer(int x, int y, int countDecker, out string msg)
{
    msg = String.Empty;
    if (x < 0 || x + countDecker > Size || y < 0 || y  > Size)
    {
        msg = "Данная ячейка вышла за границы, введите еще раз:";
        return false;
    }
    bool flag = false;
    for (var i = x; i <= x + countDecker - 1; i++)
    {
        if (i < 0 || y < 0 || i >= Size || y >= Size) continue;
        if ((board[i, y] == 'X') || board[i, y] == '1')
        {
            flag = true;
            break;
        }
    }

    if (flag)
    {
        msg = "Данная ячейка занята кораблем (или расположена возле корабля), введите еще раз:";
        return false;
    }

    return true;
}

bool IsValidPlaceHor(int x, int y, int countDecker, out string msg)
{
    msg = String.Empty;
    if (x < 0 || x  > Size || y < 0 || y + countDecker > Size)
    {
        msg = "Данная ячейка вышла за границы, введите еще раз:";
        return false;
    }
    bool flag = false;
    for (var i = y; i <= y + countDecker - 1; i++)
    {
        if (i < 0 || x < 0 || i >= Size || x >= Size) continue;
        if ((board[x, i] == 'X') || board[x, i] == '1')
        {
            flag = true;
            break;
        }
    }

    if (flag)
    {
        msg = "Данная ячейка занята кораблем (или расположена возле корабля), введите еще раз:";
        return false;
    }

    return true;
}


void SingleDeckShips()
{
    int x;
    int y;

    SingleDeckerFlag = true;

    for (int i = 0; i < 4; i++)
    {
        try
        {
            VvodCoordinates(i, out x, out y,"однопалубного");
            var msg = "";
            if (IsValidPlaceHor(x, y, 1, out msg))
            {
                board[x, y] = 'X';
                IsOccupiedCellsHor(x, y, 1);
            }
            else
            {
                throw new Exception(msg);
            }


            Console.Clear();
            Board();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            i--;
        }
    }
}

void DoubleDeckerShips()
{
    int x;
    int y;

    DoubleDeckerFlag = true;

    for (int i = 0; i < 3; i++)
    {
        try
        {
            var direction = Direction();
            VvodCoordinates(i, out x, out y, "двухпалубного");
            var msg = "";
            if (direction == "v")
            {
                if (IsValidPlaceVer(x, y,2, out msg) )
                {
                    board[x, y] = 'X';
                    board[x + 1, y] = 'X';
                    IsOccupiedCellsVer(x, y, 2);
                }
                else
                {
                    throw new Exception(msg);
                }
            }
            if (direction == "h")
            {
                if (IsValidPlaceHor(x, y, 2, out msg)) 
                {
                    board[x, y] = 'X';
                    board[x, y + 1] = 'X';
                    IsOccupiedCellsHor(x, y, 2);
                }
                else
                {
                    throw new Exception(msg);
                }
            }
            Console.Clear();
            Board();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            i--;
        }
    }

}

void ThreeDeckerShips()
{
    int x;
    int y;

    ThreeDeckerFlag = true;

    for (int i = 0; i < 2; i++)
    {
        try
        {
            var direction = Direction();
            VvodCoordinates(i, out x, out y, "трехпалубного");
            var msg = "";
            if (direction == "v")
            {
                if (IsValidPlaceVer(x, y, 3, out msg))
                {
                    board[x, y] = 'X';
                    board[x + 1, y] = 'X';
                    board[x + 2, y] = 'X';
                    IsOccupiedCellsVer(x, y, 3);
                }
                else
                {
                    throw new Exception(msg);
                }
            }
            if (direction == "h")
            {
                if (IsValidPlaceHor(x, y, 3, out msg))
                {
                    board[x, y] = 'X';
                    board[x, y + 1] = 'X';
                    board[x, y + 2] = 'X';
                    IsOccupiedCellsHor(x, y, 3);
                }
                else
                {
                    throw new Exception(msg);
                }
            }
            Console.Clear();
            Board();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            i--;
        }
    }

}

void FourDeckerShips()
{
    int x;
    int y;

    FourDeckerFlag = true;

    for (int i = 0; i < 1; i++)
    {
        try
        {
            var direction = Direction();
            VvodCoordinates(i, out x, out y, "четырехпалубного");
            var msg = "";
            if (direction == "v")
            {
                if (IsValidPlaceVer(x, y, 4, out msg))
                {
                    board[x, y] = 'X';
                    board[x + 1, y] = 'X';
                    board[x + 2, y] = 'X';
                    board[x + 3, y] = 'X';
                    IsOccupiedCellsVer(x, y, 4);
                }
                else
                {
                    throw new Exception(msg);
                }
            }
            if (direction == "h")
            {
                if (IsValidPlaceHor(x, y, 4, out msg))
                {
                    board[x, y] = 'X';
                    board[x, y + 1] = 'X';
                    board[x, y + 2] = 'X';
                    board[x, y + 3] = 'X';
                    IsOccupiedCellsHor(x, y, 4);
                }
                else
                {
                    throw new Exception(msg);
                }
            }
            Console.Clear();
            Board();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            i--;
        }
    }

}

