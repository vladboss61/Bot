
namespace TelegramBot.Extensions
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public static class CollectionExtension
    {
        public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> @do)
        {
            foreach (var value in sequence)
            {
                @do(value);
            }
        }
    }
}
