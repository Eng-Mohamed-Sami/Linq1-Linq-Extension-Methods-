namespace Linq1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Where and indexed where

            //List<int> ints = [12, 5, 7, 8, 54, 1, 0, 41, 15, 20, 40];

            //var result = ints.filter(i => i > 12);
            //var result2 = ints.filter((num, i) => num > 5 && i > 3 && i <= 9);
            ////var result1 = ints.Where(i => i > 12);

            //foreach (int item in result2)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Select && indexed select
            //List<int> ints = [12, 5, 7, 8, 54, 1, 0, 41, 15, 20, 40];
            ////var result = ints.Select(i => i % 2 == 0);
            //var result = ints.choose(i => new { item = i, isEven = i % 2 == 0 });
            //var result2 = ints.choose((num, i) => num > 10 && i > 4);
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //} 
            #endregion

            #region Skip and skiplast
            //List<int> ints = [12, 5, 7, 8, 54, 1, 0, 41, 15, 20, 40];
            //var Result = ints.Skip(4);
            //var result1 = ints.ignorefirst(4);
            //foreach (int i in result1)
            //{
            //    Console.WriteLine(i);
            //} 

            //List<int> ints = [12, 5, 7, 8, 54, 1, 0, 41, 15, 20, 40];
            ////var Result = ints.SkipLast(3);
            //var result1 = ints.ignorelast(3);
            //foreach (int i in result1)
            //{
            //    Console.WriteLine(i);
            //}
            #endregion

            #region Take and takelast
            //List<int> ints = [12, 5, 7, 8, 54, 1, 0, 41, 15, 20, 40];
            ////var Result = ints.Take(4);
            //var result1 = ints.take(4);
            //foreach (int i in result1)
            //{
            //    Console.WriteLine(i);
            //}

            //List<int> ints = [12, 5, 7, 8, 54, 1, 0, 41, 15, 20, 40];
            ////var Result = ints.TakeLast(4);
            //var result1 = ints.takelast(4);
            //foreach (int i in result1)
            //{
            //    Console.WriteLine(i);
            //} 





            #endregion

            #region Chunk
            //List<int> ints = [12, 5, 7, 8, 54, 1, 0, 41, 15, 20, 40];
            //var result = ints.Chunk(3);
            //foreach (var chunk in result)
            //{
            //    Console.Clear();
            //    foreach (var j in chunk)
            //    {
            //        Console.WriteLine(j);
            //    }
            //    Console.ReadLine();

            //} 
            #endregion

            #region Single and singleordefault
            //List<int> ints = [12, 5, 7, 8, 54, 1, 0, 41, 15, 20, 40];
            //var result = ints.SingleOrDefault(n => n < 5);
            //Console.WriteLine(result);


            #endregion

            //List<int> ints = [12, 5, 7, 8, 54, 1, 0, 41, 15, 20, 40];
            //var res = ints.takewhile(n => n > 4);
            //foreach (int i in res)
            //{
            //    Console.WriteLine(i);
            //}

            //List<int> ints = [12, 5, 7, 8, 54, 1, 0, 41, 15, 20, 40];
            //var res = ints.skipwhile(n => n > 8);
            //foreach (int i in res)
            //{
            //    Console.WriteLine(i);
            //}

            List<int> ints = [12, 5, 7, 8, 54, 1, 0, 0, 41, 15, 20, 40];
            var res = ints.Distinct();
            //Console.WriteLine(res);
            foreach (int i in res)
            {
                Console.WriteLine(i);
            }






        }
    }
}
