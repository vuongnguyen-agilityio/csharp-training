decimal m = 1M / 6M;

void PrintLog(object st)
{
Console.WriteLine(st);
};

PrintLog(1);

Console.WriteLine(1_000_000);
//
Console.WriteLine(m + m + m + m + m + m);

Console.WriteLine(m * 6M);

double d = 1.0 / 6.0;

Console.WriteLine(d + d + d + d + d + d);

Console.WriteLine(d * 6.0);

string a1 = "\\\\server\\fileshare\\helloworld.cs";
string a2 = @"\\server\fileshare\helloworld.cs";
Console.WriteLine(a1 == a2);

string xml = @"<customer id=""123""></customer>";
Console.WriteLine($"255 in hex is {byte.MaxValue:X2}");
Console.WriteLine($"{byte.MaxValue:X2}");


//char[] vowels = {'a','e','i','o','u'};
//vowels[1] = '1';
//Console.WriteLine(vowels);

char[] vowels = new char[] {'a','e','i','o','u'};
Index first = 0;
Index last = ^1;

char firstElement = vowels [0]; // 'a'
char lastElement = vowels [^1]; // 'u'
PrintLog(firstElement.ToString());
PrintLog(lastElement.ToString());

char[] lastThree = vowels [2..]; // 'i', 'o', 'u'
char[] middleOne = vowels [2..3]; // 'i'
char[] lastTwo = vowels [^2..]; // 'o', 'u'
Range firstTwoRange = 0..2;
char[] firstTwo = vowels [firstTwoRange]; // 'a', 'e'


int[,] testmatrix = new int[,]
{
 {0,1,2},
 {3,4,5},
 {6,7,8}
};
int[,] matrix = new int[3,3];
for (int i = 0; i < matrix.GetLength(0); i++)
 for (int j = 0; j < matrix.GetLength(1); j++)
 matrix[i,j] = i * 4 + j;
Console.WriteLine(matrix);

int z = 1;
float f = z;
Console.WriteLine(z.GetType());
Console.WriteLine(f.GetType());

//Checked help to throw OverflowException to avoid overflowing silently
//int x = int.MaxValue;
//int y = checked (x + 1);
//checked { int z1 = x + 1; };

//Console.WriteLine(y);

short x1 = 1, y1 = 1;
short z2 = (short) (x1 + y1);
//In this case, x and y are implicitly converted to int so that the addition can be
//performed. This means that the result is also an int, which cannot be implicitly cast
//back to a short (because it could cause loss of data).
Console.WriteLine(z2.GetType());
Console.WriteLine(x1.GetType());
Console.WriteLine(y1.GetType());


Console.WriteLine("hi" + 1);