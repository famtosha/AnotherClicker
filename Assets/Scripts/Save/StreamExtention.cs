using System.IO;
using System;
using UnityEngine;

public static class StreamExtention
{
    public static void WriteBytes(this Stream stream, byte[] bytes)
    {
        stream.Write(bytes, 0, bytes.Length);
    }

    public static void WriteInt(this Stream stream, int num)
    {
        var bytes = BitConverter.GetBytes(num);
        stream.WriteBytes(bytes);
    }

    public static void WriteCoinModifer(this Stream stream, CoinModifier modifier)
    {
        stream.WriteInt(modifier.modifierID);
    }

    public static void WriteArray<T>(this Stream stream, T[] array, Action<Stream, T> writeAction)
    {
        stream.WriteInt(array.Length);
        foreach (var element in array)
        {
            writeAction(stream, element);
        }
    }

    public static void WriteArray(this Stream stream, int[] array)
    {
        WriteArray(stream, array, (x, y) => x.WriteInt(y));
    }

    public static void WriteArray(this Stream stream, CoinModifier[] array)
    {
        WriteArray(stream, array, (x, y) => x.WriteInt(y.modifierID));
    }

    public static byte[] ReadBytes(this Stream stream, int count)
    {
        byte[] buffer = new byte[count];
        var x = stream.Read(buffer, 0, buffer.Length);
        //Debug.Log(stream.Position - count + " " + x + " " + ToString(buffer));
        return buffer;
    }

    public static string ToString(byte[] bytes)
    {
        string result = "";

        for (int i = 0; i < bytes.Length; i++)
        {
            result += bytes[i].ToString("X") + " ";
        }

        return result;
    }

    public static int ReadInt(this Stream stream)
    {
        int n = BitConverter.ToInt32(stream.ReadBytes(4), 0);
        return n;
    }

    public static T[] ReadArray<T>(this Stream stream, Func<Stream, T> readAction)
    {
        T[] array = new T[stream.ReadInt()];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = readAction(stream);
        }
        return array;
    }
}
