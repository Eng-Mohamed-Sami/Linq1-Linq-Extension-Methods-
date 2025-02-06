namespace Linq1
{
    public static class Helper
    {
        public static IEnumerable<T> filter<T>(this IEnumerable<T> Source, Func<T, bool> func)
        {
            foreach (var item in Source)
            {
                if (func(item))
                {
                    yield return item;
                }
            }
        }
        public static IEnumerable<TSource> filter<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
        {
            int count = 0;
            foreach (var item in source)
            {

                if (predicate(item, count))
                {
                    yield return item;
                }
                count++;
            }
        }
        public static IEnumerable<TResult> choose<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach (var item in source)
            {
                yield return selector(item);
            }
        }
        public static IEnumerable<TResult> choose<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TResult> selector)
        {
            int count = 0;
            foreach (var item in source)
            {
                yield return selector(item, count);
                count++;
            }
        }
        public static IEnumerable<TSource> ignorefirst<TSource>(this IEnumerable<TSource> source, int count)
        {
            int index = 0;
            foreach (var item in source)
            {
                if (index++ >= count)
                {
                    yield return item;
                }
            }


            //if (count == 0) { throw new ArgumentException(); }
            //int index = 0;
            //var enumerator = source.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    if (index > count)
            //    {
            //        yield return enumerator.Current;
            //    }
            //    index++;
            //}

        }
        public static IEnumerable<TSource> ignorelast<TSource>(this IEnumerable<TSource> source, int count)
        {
            Queue<TSource> queue = new Queue<TSource>();
            foreach (var item in source)
            {
                queue.Enqueue(item);
                if (queue.Count > count)
                {
                    yield return queue.Dequeue();
                }
            }
        }
        public static IEnumerable<TSource> take<TSource>(this IEnumerable<TSource> source, int count)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Null Sourse");
            }

            var enumerator = source.GetEnumerator();
            for (int i = 1; i <= count; i++)
            {
                if (enumerator.MoveNext())
                {
                    yield return enumerator.Current;
                }
            }
        }
        public static IEnumerable<TSource> takelast<TSource>(this IEnumerable<TSource> source, int count)
        {
            var sourceList = source.ToList();
            int skipCount = sourceList.Count - count;
            for (int i = skipCount; i < sourceList.Count; i++)
            {
                yield return sourceList[i];
            }
        }
        public static List<int> chunk(this List<int> list, int x)
        {
            var Newlist = new List<int>();

            for (int i = 0; i < list.Count; i += x)
            {
                var chunk = list.ignorefirst(i).take(x).ToList();

                Console.WriteLine($"chunk is:");

                foreach (var item in chunk)
                {
                    Newlist.Add(item);
                }
            }

            return Newlist;
        }
        public static T single<T>(this IEnumerable<T> list, Func<T, bool> predicate)
        {
            var result = list.filter(predicate).ToList();

            if (result.Count == 1)
            {
                return result[0];
            }
            else if (result.Count == 0)
            {
                throw new Exception("Element not found");
            }
            else
            {
                throw new ArgumentOutOfRangeException("More than one element matches the condition");
            }



        }
        public static T singleordefault<T>(this IEnumerable<T> list, Func<T, bool> predicate)
        {
            bool found = false;
            T result = default;
            foreach (var item in list)
            {
                if (predicate(item))
                {
                    if (found)
                    {
                        return default;
                    }
                    result = item;
                    found = true;
                }
            }
            return result;
        }
        public static IEnumerable<TSource> takewhile<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (var item in source)
            {
                if (!predicate(item))
                {
                    yield break;
                }
                yield return item;
            }

        }
        public static IEnumerable<TSource> skipwhile<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            bool skipping = true;

            foreach (var item in source)
            {
                if (skipping && predicate(item))
                {
                    continue;
                }

                skipping = false;
                yield return item;
            }
        }
        public static IEnumerable<TSource> orderby<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, int> comparer)
        {
            List<TSource> list = source.ToList();
            for (var i = 0; i < list.Count - 1; i++)
            {
                for (var j = 0; j < list.Count - i - 1; j++)
                {
                    if (comparer(list[j], list[j + 1]) > 0)
                    {
                        var temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }

            foreach (var item in list)
            {
                yield return item;
            }
        }
        public static T first<T>(this IEnumerable<T> source)
        {

            foreach (var item in source)
            {
                return item;
            }
            throw new InvalidOperationException("Sequence contains no elements.");
        }
        public static T FirstOrDefault<T>(this IEnumerable<T> source)
        {
            foreach (var item in source)
            {
                return item;
            }
            return default;
        }
        public static T Last<T>(this IEnumerable<T> source)
        {
            T last = default;
            bool found = false;

            foreach (var item in source)
            {
                last = item;
                found = true;
            }

            if (!found)
            {
                throw new InvalidOperationException("Sequence contains no elements.");
            }

            return last;
        }
        public static T LastOrDefault<T>(this IEnumerable<T> source)
        {
            T last = default;
            bool found = false;

            foreach (var item in source)
            {
                last = item;
                found = true;
            }
            if (!found)
            {
                last = default;
            }
            return last;

        }
        public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source)
        {
            HashSet<TSource> seen = new HashSet<TSource>();

            foreach (var item in source)
            {
                if (seen.Add(item))
                {
                    yield return item;
                }
            }
        }



    }
}
