using System;

namespace Demo.BenchmarkDotNet.Library
{
    public static class Util
    {
        public static T[] GetACopyOf<T>(T[] arr)
        {
            T[] tempArray = (T[])Array.CreateInstance(typeof(T), arr.Length);
            Array.Copy(arr, tempArray, arr.Length);
            return tempArray;
        }
    }
}
