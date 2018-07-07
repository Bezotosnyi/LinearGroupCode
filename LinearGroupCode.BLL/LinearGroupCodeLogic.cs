// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LinearGroupCodeLogic.cs" company="Dnu">
//   Dima Bezotosnyi
// </copyright>
// <summary>
//   Defines the LinearGroupCodeLogic type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace LinearGroupCode.BLL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Линейные групповые коды
    /// </summary>
    public sealed class LinearGroupCodeLogic
    {
        /// <summary>
        /// Порождающая матрица
        /// </summary>
        private static Bit[,] G;

        /// <summary>
        /// Проверочная подматрица матрицы G
        /// </summary>
        private static Bit[,] C;

        /// <summary>
        /// Минимальное кодовое расстояние
        /// </summary>
        private static int dmin;

        /// <summary>
        /// Количество информационных бит
        /// </summary>
        public static int k { get; private set; }

        /// <summary>
        /// Количество проверочных бит
        /// </summary>
        private static int r;

        /// <summary>
        /// Число столбцов производящей матрицы
        /// </summary>
        private static int n;

        /// <summary>
        /// Проверочная матрица
        /// </summary>
        private static Bit[,] H;

        /// <summary>
        /// Описание процесса обнаружения и исправления ошибки
        /// </summary>
        public StringBuilder ProcessDetected { get; set; } = new StringBuilder();

        /// <summary>
        /// Получение порождающей матрицы
        /// </summary>
        /// <param name="alphabeticSize">Объем алфавита</param>
        /// <param name="rankDetect">Ранк ошибки, которую необходимо обнаружить. По умолчанию 0</param>
        /// <param name="rankFix">Ранк ошибки, которую необходимо исправить. По умолчанию 1</param>
        /// <returns>Порождающая матрица</returns>
        public Bit[,] GetGeneratingMatrix(int alphabeticSize, int rankDetect = 0, int rankFix = 1)
        {
            // определяем основные параметры
            k = (int)Math.Ceiling(Math.Log(alphabeticSize, 2));
            if (rankDetect == 0)
                dmin = (2 * rankFix) + 1;
            else if (rankFix == 0)
                dmin = rankDetect + 1;
            else
            {
                if (rankDetect < rankFix)
                    throw new LinearGroupCodeException(
                              $"Значение {nameof(rankDetect)} должно быть больше чем значение {rankFix}");
                dmin = rankDetect + rankFix + 1;
            }

            r = this.GetCheckBitCount(dmin, k);
            n = k + r;

            this.ProcessDetected.AppendLine($"{nameof(k)} = {k}");
            this.ProcessDetected.AppendLine($"{nameof(dmin)} = {dmin}");
            this.ProcessDetected.AppendLine($"{nameof(r)} = {r}");
            this.ProcessDetected.AppendLine($"{nameof(n)} = {nameof(k)} + {nameof(r)} = {n}");

            G = new Bit[k, n];
            C = new Bit[k, r];

            this.ProcessDetected.AppendLine($"Создаем производящую матрицу {nameof(G)}[{k}, {n}]");

            // заполняем еденичную леводиагональную матрицу
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    if (i == j) G[i, j] = 1;
                    else G[i, j] = 0;
                }
            }

            // список с проверочными битами, которые соотвествуют условию >= dmin - 1
            List<string> checkBitStrList = new List<string>();

            // идем по массиву всех возможных проверочных бит и формируем список 
            foreach (var checkBitStr in this.GetAllCheckBits(r))
                if (checkBitStr.ToBitArray().GetCountBitN(1) >= dmin - 1)
                    checkBitStrList.Add(checkBitStr);

            this.ProcessDetected.AppendLine(@"Проверочные биты, где к-во '1' >= dmin - 1:");
            this.ProcessDetected.AppendLine(
                checkBitStrList.Aggregate(string.Empty, (current, s) => current + s.ToBitArray().ArrayToString() + " "));
            this.ProcessDetected.AppendLine($"До еденичной матрицы дописываем проверочные биты и получаем матрицу {nameof(G)}:");

            // до еденичной матрицы дописываем проверочную + заполняем проверочную подматрицу матрицы G
            // (она пригодится для метода обнаружения и исправления ошибок)
            for (int i = 0; i < k; i++)
            {
                // если у нас всего 1 проверочный бит, то берем его, в противном случаи - берем i
                var checkBit = checkBitStrList.Count == 1
                                   ? checkBitStrList[0].ToBitArray()
                                   : checkBitStrList[i].ToBitArray();
                for (int j = k, t = 0; j < n; j++, t++)
                {
                    G[i, j] = checkBit[t];
                    C[i, t] = checkBit[t];
                }
            }

            this.ProcessDetected.AppendLine(G.BinaryArrayToString(" "));

            return G;
        }

        /// <summary>
        /// Получение кодового вектора
        /// </summary>
        /// <param name="sourceCode">Исходный код</param>
        /// <returns>Кодовый вектор</returns>
        public Bit[] GetVectorCode(string sourceCode)
        {
            if (sourceCode.Length != k) throw new LinearGroupCodeException($"Неправильная длина исходного кода. Должна быть {k}");

            Bit[] sourceBit = sourceCode.ToBitArray();
            Bit[] vectorCode = new Bit[k + r];

            List<int> position1List = new List<int>();

            // считаем на каком месте стоят 1 чтобы узнать какие строчки порождающей матрицы суммировать
            for (int i = 0; i < sourceBit.Length; i++)
                if (sourceBit[i] == 1)
                    position1List.Add(i);

            this.ProcessDetected.AppendLine($"Принятый код: {sourceBit.ArrayToString(" ")}");
            this.ProcessDetected.AppendLine($"Длина вектора должна быть {nameof(k)} + {nameof(r)} = {k + r}");
            this.ProcessDetected.AppendLine(@"Считаем на каком месте стоят 1 в принятом векторе:");
            this.ProcessDetected.AppendLine(position1List.Select(x => x + 1).ArrayToString(" "));

            // обнуляем вектор
            for (int i = 0; i < vectorCode.Length; i++)
                vectorCode[i] = 0;

            this.ProcessDetected.AppendLine("Суммируем эти строки:");

            // суммируем строки
            foreach (var position in position1List)
            {
                for (int i = 0; i < vectorCode.Length; i++)
                {
                    vectorCode[i] ^= G[position, i];
                    this.ProcessDetected.Append($"{G[position, i].ToString()} ");
                }

                this.ProcessDetected.AppendLine();
            }

            this.ProcessDetected.AppendLine(@"И получаем вектор:");
            this.ProcessDetected.AppendLine($"{vectorCode.ArrayToString(" ")}");

            return vectorCode;
        }

        /// <summary>
        /// Обнаружение и исправление одиночной ошибки
        /// </summary>
        /// <param name="recivedVector">Принятый вектор</param>
        /// <returns>Структура с параметрами <see cref="ParametrsDetectedError"/></returns>
        public ParametrsDetectedError DetectedAndCorrectError(string recivedVector)
        {
            if (dmin < 3)
                throw new LinearGroupCodeException(
                          $"Неправильное значение {nameof(dmin)} ({dmin}). "
                          + $"Для исправления однократной ошибки {nameof(dmin)} должно быть не меньше {3}");

            if (recivedVector.Length != n) throw new LinearGroupCodeException($"Неправильная длина полученого вектора. Должна быть {n}");

            Bit[] recived = recivedVector.ToBitArray();
            Bit[] recivedSyndrome = this.GetRecivedSyndrom(recived);
            Bit[] syndrome = new Bit[r];
            int errorBit = -1;
            H = new Bit[r, n];

            this.ProcessDetected.AppendLine($"Принятый вектор: {recived.ArrayToString(" ")}");
            this.ProcessDetected.AppendLine($"Подматрица {nameof(C)}:");
            this.ProcessDetected.AppendLine(C.BinaryArrayToString(" "));

            // транспонируем проверочную подматрицу C
            var tranposeMatrix = this.TransposeMatrix(C);

            this.ProcessDetected.AppendLine($"Транспонированая подматрица {nameof(C)}:");
            this.ProcessDetected.AppendLine(tranposeMatrix.BinaryArrayToString(" "));

            // записываем в H транспонированую матрицу
            for (int i = 0; i < r; i++) for (int j = 0; j < k; j++) H[i, j] = tranposeMatrix[i, j];

            // дописываем проверочную матрицу до H
            for (int i = 0; i < r; i++)
            {
                for (int j = k; j < n; j++)
                {
                    if (i == j - k) H[i, j] = 1;
                    else H[i, j] = 0;
                }
            }

            this.ProcessDetected.AppendLine($"Матрица {nameof(H)}:");
            this.ProcessDetected.AppendLine(H.BinaryArrayToString(" "));
            this.ProcessDetected.AppendLine($"Принятый синдром: {recivedSyndrome.ArrayToString(" ")}");
            this.ProcessDetected.AppendLine("Вычисление синдрома:");

            // вычисляем синдром
            for (int i = 0; i < r; i++)
            {
                syndrome[i] = recivedSyndrome[i];
                this.ProcessDetected.Append($"S{i + 1} = {syndrome[i].ToString()}");
                for (int j = 0; j < k; j++)
                {
                    if (H[i, j] == 1)
                    {
                        syndrome[i] ^= recived[j];
                        this.ProcessDetected.Append($" ^ {recived[j].ToString()}");
                    }

                    if (j == k - 1) this.ProcessDetected.Append($" = {syndrome[i].ToString()}");
                }

                this.ProcessDetected.AppendLine();
            }

            this.ProcessDetected.AppendLine($"Синдром: {syndrome.ArrayToString(" ")}");
            this.ProcessDetected.AppendLine($"Матрица {nameof(H)}");
            this.ProcessDetected.AppendLine(H.BinaryArrayToString(" "));

            // поиск ошибочного бита
            for (int j = 0; j < n; j++)
            {
                bool equals = true;
                for (int i = 0; i < r; i++)
                {
                    if (syndrome[i] != H[i, j])
                    {
                        equals = false;
                        break;
                    }
                }

                if (equals)
                {
                    errorBit = j;
                    break;
                }
            }

            // исправляем ошибку в бите
            if (errorBit != -1)
            {
                recived[errorBit] ^= 1;
                this.ProcessDetected.AppendLine($"Номер ошибочного бита: {errorBit + 1}");
                this.ProcessDetected.AppendLine($"Код с исправленной ошибкой: {recived.ArrayToString(" ")}");
            }
            else this.ProcessDetected.AppendLine("В принятом коде нет ошибок");

            return new ParametrsDetectedError(syndrome, errorBit + 1, recived);
        }

        /// <summary>
        /// Получение массива всех возможных проверочных бит (числа от 0 до 2^(r - 1))
        /// </summary>
        /// <param name="bitSize">Длина бита</param>
        /// <returns>Массив всех возможных проверочных бит</returns>
        private string[] GetAllCheckBits(int bitSize)
        {
            // если длина бита = 1, будут 2 значений 0 и 1
            if (bitSize == 1) return new[] { "0", "1" };

            List<string> allCheckBitsArray = new List<string>();

            int maxDecimalNumber = (int)Math.Pow(2, bitSize) - 1;

            for (int i = 0; i <= maxDecimalNumber; i++) allCheckBitsArray.Add(this.GetBinaryNumber(i, bitSize));

            return allCheckBitsArray.ToArray();
        }

        /// <summary>
        /// Перевод целого числа в двоичную систему с указанной длиной кода
        /// </summary>
        /// <param name="number">Целое число для перевода</param>
        /// <param name="bitSize">Длина кода</param>
        /// <returns>Строка с двоичным числом</returns>
        private string GetBinaryNumber(int number, int bitSize)
        {
            string binaryNumberStr = string.Empty;

            // перевод в двоичную систему
            do
            {
                binaryNumberStr = (number % 2) + binaryNumberStr;
                number /= 2;
            }
            while (number > 0);

            // дописываем слева нолики чтобы прировнятся к bitSize
            while (binaryNumberStr.Length != bitSize) binaryNumberStr = "0" + binaryNumberStr;

            return binaryNumberStr;
        }

        /// <summary>
        /// Определение количества проверочных бит (r)
        /// </summary>
        /// <param name="minCodeDistance">Минимальное кодовое расстояние </param>
        /// <param name="countInformationBit">Количество информационных бит</param>
        /// <returns>Количество проверочных бит</returns>
        private int GetCheckBitCount(int minCodeDistance, int countInformationBit)
        {
            int checkBitCount;

            if (countInformationBit > 10 || countInformationBit < 1)
                throw new LinearGroupCodeException(
                          $"Значение {nameof(countInformationBit)} должно быть в диапазоне 1 - 10");
            switch (minCodeDistance)
            {
                case 2:
                    checkBitCount = 1;
                    break;

                case 3:
                    switch (countInformationBit)
                    {
                        case 1:
                            checkBitCount = 2;
                            break;

                        case 2:
                        case 3:
                        case 4:
                            checkBitCount = 3;
                            break;

                        default:
                            checkBitCount = 4;
                            break;
                    }

                    break;

                case 4:
                    switch (countInformationBit)
                    {
                        case 1:
                            checkBitCount = 3;
                            break;

                        case 2:
                        case 3:
                            checkBitCount = 5;
                            break;

                        case 4:
                        case 5:
                            checkBitCount = 6;
                            break;

                        default:
                            if (countInformationBit >= 6 && countInformationBit <= 9) checkBitCount = 7;
                            else checkBitCount = 8;
                            break;
                    }

                    break;

                case 5:
                    switch (countInformationBit)
                    {
                        case 1:
                            checkBitCount = 4;
                            break;

                        case 2:
                            checkBitCount = 7;
                            break;

                        case 3:
                        case 4:
                            checkBitCount = 8;
                            break;

                        case 5:
                        case 6:
                            checkBitCount = 9;
                            break;

                        default:
                            if (countInformationBit >= 7 && countInformationBit <= 9) checkBitCount = 10;
                            else checkBitCount = 11;
                            break;
                    }

                    break;

                default:
                    throw new LinearGroupCodeException(
                              $"Значение {nameof(minCodeDistance)} должно быть в диапазоне 2 - 5");
            }

            return checkBitCount;
        }

        /// <summary>
        /// Транспонирование матрицы
        /// </summary>
        /// <param name="matrix">Обычная матрица</param>
        /// <remarks>Нужно просто поменять строки со столбцами</remarks>
        /// <returns>Транспонированая матрица</returns>
        private Bit[,] TransposeMatrix(Bit[,] matrix)
        {
            Bit[,] tranposeMatrix = new Bit[matrix.GetLength(1), matrix.GetLength(0)];

            for (int i = 0; i < tranposeMatrix.GetLength(0); i++) for (int j = 0; j < tranposeMatrix.GetLength(1); j++) tranposeMatrix[i, j] = matrix[j, i];

            return tranposeMatrix;
        }

        /// <summary>
        /// Получение синдрома из принятого вектора
        /// </summary>
        /// <param name="receivedVector">Принятый вектор</param>
        /// <returns>Синдром</returns>
        private Bit[] GetRecivedSyndrom(Bit[] receivedVector)
        {
            Bit[] recivedSyndrom = new Bit[r];

            for (int i = 0, j = k; j < receivedVector.Length; j++, i++) recivedSyndrom[i] = receivedVector[j];

            return recivedSyndrom;
        }

        /// <summary>
        /// Параметры обнаруженной ошибки
        /// </summary>
        public struct ParametrsDetectedError
        {
            public ParametrsDetectedError(Bit[] syndrome, int numberErrorBit, Bit[] correct)
            {
                this.Syndrome = syndrome;
                this.NumberErrorBit = numberErrorBit;
                this.CorrectRecivedVector = correct;
            }

            /// <summary>
            /// Синдром
            /// </summary>
            public Bit[] Syndrome { get; private set; }

            /// <summary>
            /// Номер ошибочного бита
            /// </summary>
            public int NumberErrorBit { get; private set; }

            /// <summary>
            /// Правильный принятый вектор
            /// </summary>
            public Bit[] CorrectRecivedVector { get; private set; }
        }
    }
}