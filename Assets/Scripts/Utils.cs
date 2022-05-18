using System;
using System.Collections;
using System.Collections.Generic;
using Random = System.Random;

public static class Utils
{
    /// <summary>
    /// Shuffles collection with given seed. Read more at <a href="https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle">wiki</a>
    /// </summary>
    /// <param name="collection"></param>
    /// <param name="seed"></param>
    public static void Shuffle(this IList collection, int seed)
    {
        Random rnd = new Random(seed);

        for (int i = collection.Count - 1; i > 0; i--)
        {
            int j = rnd.Next(0, i + 1);
            (collection[i], collection[j]) = (collection[j], collection[i]);
        }
    }
}
