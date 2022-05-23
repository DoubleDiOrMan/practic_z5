using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema_5
{
    /// <summary>
    /// Класс, который содержит методы для поиска минимальных значений внутри массива.
    /// </summary>

    public class multiply2
    {
        
        /// <summary>
        /// Метод для поиска первого минимального значения
        /// </summary>
        /// <param name="arr">Массив</param>
        /// <param name="ind">Индекс</param>
        /// <returns>Первое минимальное значение внутри массива</returns>

        public static int Min(int[] arr, out int ind)
        {
            int a;
            a = arr[0];
            ind = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < a)
                {
                    ind = i;
                    a = arr[i];
                }
            }
            return a;
        }

        /// <summary>
        /// Метод для поиска последнего минимального значения
        /// </summary>
        /// <param name="arr">Массив</param>
        /// <returns>Индекс последнего минимального значения внутри массива</returns>

        public static int LastMin(int[] arr)
        {
            int a = multiply2.Min(arr, out int ind);
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] == a)
                {
                    return i;
                }
            }
            return ind;
        }
    }
}
