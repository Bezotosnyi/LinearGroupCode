// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="DNU">
//   Dima Bezotosnyi
// </copyright>
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LinearGroupCode.Console
{
    using System;
    using BLL;

    public class Program
    {
        public static void Main(string[] args)
        {
            LinearGroupCodeLogic l = new LinearGroupCodeLogic();
            Console.WriteLine(l.GetGeneratingMatrix(16).BinaryArrayToString());
            Console.WriteLine();
            Console.WriteLine("vector  " + l.GetVectorCode("1011").ArrayToString());
            var s = l.DetectedAndCorrectError("1011011");
            Console.WriteLine("syndrome " + s.Syndrome.ArrayToString());
            Console.WriteLine("error bit " + s.NumberErrorBit);
            Console.WriteLine("correct " + s.CorrectRecivedVector.ArrayToString());
            Console.WriteLine();
            Console.WriteLine(l.ProcessDetected.ToString());

            Console.ReadKey();
        }
    }
}