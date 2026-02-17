namespace IDED_Scripting_202610_P1
{
    internal class TestMethods
    {
        public static void SeparateElements(Queue<int> input, out Stack<int> included, out Stack<int> excluded)
        {
            included = new Stack<int>();
            excluded = new Stack<int>();

            while (input.Count > 0) //para q sea hasat q quede vacia
            {
                int x = input.Dequeue(); 

                int abs = Math.Abs(x);
                int n = (int)Math.Sqrt(abs);

                bool belongs = false;

                if (n * n == abs)
                {
                    if ((n % 2 == 0 && x > 0) || (n % 2 == 1 && x < 0))
                        belongs = true;
                }

                if (belongs)
                    included.Push(x);
                else
                    excluded.Push(x);
            }

        }

        public static List<int> GenerateSortedSeries(int n)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < n; i++)
            {
                int term;

                if (i % 2 == 0)
                    term = i * i;
                else
                    term = -i * i;

                result.Add(term);
            }

            result.Sort();

            return result;
        }

        public static bool FindNumberInSortedList(int target, in List<int> list)
        {
            int n = list.Count;

            List<int> temp = new List<int>();

            for (int i = 0; i < n; i++)
                temp.Add(list[i]);

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (temp[j] < temp[j + 1])
                    {
                        int aux = temp[j];
                        temp[j] = temp[j + 1];
                        temp[j + 1] = aux;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (temp[i] == target)
                    return true;
            }

            return false;
        }

        public static int FindPrime(in Stack<int> list)
        {
            Stack<int> temp = new Stack<int>();
            Stack<int> work = new Stack<int>(list);

            while (work.Count > 0)
                temp.Push(work.Pop());

            while (temp.Count > 0)
            {
                int x = temp.Pop();
                if (IsPrime(x))
                    return x;
            }
            return 0;
        }

        public static bool IsPrime(int n)
        {
            bool isPrime = true;

            if (n < 2)
                isPrime = false;
            else
            {
                for (int i = 2; i * i <= n; i++) //amo hacer las de chequear primos
                {
                    if (n % i == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static Stack<int> RemoveFirstPrime(in Stack<int> stack)
        {
            Stack<int> temp1 = new Stack<int>(stack);
            Stack<int> copy = new Stack<int>();

            while (temp1.Count > 0)
                copy.Push(temp1.Pop());

            bool removed = false;
            Stack<int> temp2 = new Stack<int>();


            while (copy.Count > 0)
            {
                int x = copy.Pop();

                if (!removed && IsPrime(x))
                    removed = true;
                else
                    temp2.Push(x);
            }

            Stack<int> result = new Stack<int>();

            while (temp2.Count > 0)
                result.Push(temp2.Pop());

            return result;
        }

        public static Queue<int> QueueFromStack(Stack<int> stack)
        {
            Stack<int> temp = new Stack<int>();
            Queue<int> queue = new Queue<int>();

            while (stack.Count > 0)
                temp.Push(stack.Pop());

            while (temp.Count > 0)
            {
                int x = temp.Pop();
                stack.Push(x);   
                queue.Enqueue(x);  
            }

            return queue;
        }
    }
}