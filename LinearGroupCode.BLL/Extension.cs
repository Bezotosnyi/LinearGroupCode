// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Extension.cs" company="DNU">
//   Dima Bezotosnyi
// </copyright>
// <summary>
//   Defines the Extension type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace LinearGroupCode.BLL
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Расширение некоторых возможностей стандартных типов, в том числе и типа Bit
    /// </summary>
    public static class Extension
    {
        /// <summary>
        /// Переводит массив битов в строку
        /// </summary>
        /// <param name="bitArray">Массив битов</param>
        /// <param name="separator">Разделитель элементов</param>
        /// <typeparam name="T">Тип данных массива</typeparam>
        /// <returns>Строка из массива битов</returns>
        public static string ArrayToString<T>(this IEnumerable<T> bitArray, string separator = "")
        {
            return bitArray.Aggregate(string.Empty, (current, bit) => current + (bit + separator));
        }

        /// <summary>
        /// Переводит 2d массив битов в строку
        /// </summary>
        /// <param name="bitArray">Массив битов</param>
        /// <param name="separator">Разделитель элементов</param>
        /// <typeparam name="T">Тип данных массива</typeparam>
        /// <returns>Строка из 2d массива битов</returns>
        public static string BinaryArrayToString<T>(this T[,] bitArray, string separator = "")
        {
            StringBuilder stringBitArray = new StringBuilder();

            for (int i = 0; i < bitArray.GetLength(0); i++)
            {
                string str = string.Empty;
                for (int j = 0; j < bitArray.GetLength(1); j++)
                {
                    str += bitArray[i, j] + separator;
                }

                stringBitArray.Append(str);
                if (i <= bitArray.GetLength(0) - 2) stringBitArray.AppendLine();
            }

            return stringBitArray.ToString();
        }

        /// <summary>
        /// Возвращает массив битов
        /// </summary>
        /// <param name="str">Строка, которая содержит биты</param>
        /// <returns>Массив битов</returns>
        internal static Bit[] ToBitArray(this string str)
        {
            var listBit = new List<Bit>();
            try
            {
                listBit.AddRange(str.Select(Bit.Parse));
            }
            catch
            {
                throw new LinearGroupCodeException("Ошибка при конвертации строки в биты");
            }
            
            return listBit.ToArray();
        }

        /// <summary>
        /// Возвращает количество повторений <paramref name="value"/> в массиве Bit
        /// </summary>
        /// <param name="bitArray">Массив бит</param>
        /// <param name="value">Количество повторений <value>0</value> либо <value>1</value></param>
        /// <returns>Количество единиц</returns>
        internal static int GetCountBitN(this Bit[] bitArray, Bit value)
        {
            return bitArray.Count(bit => bit == value);
        }
    }
}