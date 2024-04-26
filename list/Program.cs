namespace list
{
    internal class Program
    {
        public static void Main()
        {
            Menu();
        }
        
        public class ListNode
        {
            public float Value { get; }
            public ListNode NextNode { get; set; }

            public ListNode(float value)
            {
                Value = value;
                NextNode = null;
            }
        }
        
        public class LinkedList
        {
            private ListNode Head { get; set; }

            public int Size { get; set; } 

            public LinkedList()
            {
                Head = null;
                Size = 0;
            }

            public ListNode this[int value]
            {
                get
                {
                    var current = Head;
                    
                    for (var i = 0; i < value; i++)
                    {
                        current = current.NextNode;
                    }

                    return current;
                }
            }
            
            public void Add(float value)
            {
                if (Head is null)
                {
                    Head = new ListNode(value);
                }
                else
                {
                    if (Size < 2)
                    {
                        var currentNode = Head;

                        for (var i = 0; i < Size - 1; i++)
                        {
                            currentNode = currentNode.NextNode;
                        }

                        currentNode.NextNode = new ListNode(value);
                    }
                    else
                    {
                        var newNode = new ListNode(value);
                        newNode.NextNode = this[2];
                        this[1].NextNode = newNode;
                    }
                }

                Size++;
            }

            public float FirstLargerThan(float value)
            {
                var list = this;
                var result = float.NaN;

                for (var i = 0; i < Size; i++)
                {
                    if (list[i].Value > 2 * value)
                    {
                        result = list[i].Value;
                        return result;
                    }
                }
                
                return result;
            }

            public int LargerThanPiAmount()
            {
                var pi = 3.14f;
                var list = this;
                var counter = 0;
                
                for (var i = 0; i < Size; i++)
                {
                    if (list[i].Value > pi)
                    {
                        counter++;
                    }
                }

                return counter;
            }

            public LinkedList NewListLargerThan(float value)
            {
                var list = this;
                var newList = new LinkedList();

                for (var i = 0; i < Size; i++)
                {
                    if (list[i].Value > value)
                    {
                        newList.Add(list[i].Value);
                    }
                }
                
                return newList;
            }

            public void DeleteLargerThanAverage()
            {
                var list = this;
                var average = 0f;

                for (var i = 0; i < Size; i++)
                {
                    average += list[i].Value;
                }

                average /= Size;

                for (var i = 0; i < Size; i++)
                {
                    if (list[i].Value > average)
                    {
                        if (i == 0)
                        {
                            Head = Head.NextNode;
                        }
                        else
                        {
                            list[i - 1].NextNode = list[i].NextNode;
                        }
                        
                        Size--;
                        i--;
                    }
                }
            }
        }

        private static void Menu()
        {
            var end = false;
            var lists = new LinkedList[100];
            var names = new string[100];
            var listsCount = 0;
            do
            {
                Console.WriteLine("1.Show lists\n" +
                                  "2.Create new list\n" +
                                  "3.Exit\n" +
                                  "Choose option:");
                var chosen1 = false;
                var chosen2 = false;
                var end1 = false;

                do
                {
                    var choice1 = Console.ReadLine();

                    switch (choice1)
                    {
                        case "1":
                            do
                            {
                                end1 = false;
                                chosen1 = true;

                                if (listsCount == 0)
                                {
                                    Console.WriteLine("There is no lists yet");
                                    break;
                                }

                                for (var i = 0; i < listsCount; i++)
                                {
                                    Console.WriteLine($"{i + 1}.{names[i]}");
                                }

                                Console.WriteLine("Choose list or type 0 to go back:");

                                var choice2 = int.Parse(Console.ReadLine());

                                if (choice2 == 0)
                                {
                                    end1 = true;
                                }
                                else
                                {
                                    do
                                    {
                                        Console.WriteLine("1.Add element (after second element if there are two)\n" +
                                                          "2.Find first twice larger value in the list than yours\n" +
                                                          "3.Count amount of values larger than 3.14\n" +
                                                          "4.New list with values larger than yours\n" +
                                                          "5.Delete all elements larger than average\n" +
                                                          "6.Show elements\n" +
                                                          "7.Go back\n" +
                                                          "Choose option:");
                                        var choice3 = Console.ReadLine();

                                        switch (choice3)
                                        {
                                            case "1":
                                                Console.WriteLine("Write value to add:");
                                                var value1 = float.Parse(Console.ReadLine());
                                                lists[choice2 - 1].Add(value1);
                                                break;
                                            case "2":
                                                Console.WriteLine("Write a value to compare to:");
                                                var value2 = float.Parse(Console.ReadLine());
                                                var result = lists[choice2 - 1].FirstLargerThan(value2);
                                                if (result is float.NaN)
                                                {
                                                    Console.WriteLine("There is no such a value");
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"Result:{result}");
                                                }
                                                break;
                                            case "3":
                                                Console.WriteLine($"Larger than 3,14 count: {lists[choice2 - 1].LargerThanPiAmount()}");
                                                break;
                                            case "4":
                                                Console.WriteLine("Write value to compare to:");
                                                var value3 = float.Parse(Console.ReadLine());
                                                Console.WriteLine("Enter new list name:");
                                                var nameList = Console.ReadLine();
                                                lists[listsCount] = lists[choice2 - 1].NewListLargerThan(value3);
                                                names[listsCount] = nameList;
                                                listsCount++;
                                                break;
                                            case "5":
                                                lists[choice2 - 1].DeleteLargerThanAverage();
                                                break;
                                            case "6":
                                                for (var i = 0; i < lists[choice2 - 1].Size; i++)
                                                {
                                                    Console.Write($"{lists[choice2 - 1][i].Value} ");
                                                }

                                                if (lists[choice2 - 1].Size == 0)
                                                {
                                                    Console.Write("Empty");
                                                }

                                                Console.WriteLine();
                                                break;
                                            case "7":
                                                chosen2 = true;
                                                break;
                                            default:
                                                Console.WriteLine("Wrong option. Try again:");
                                                chosen2 = false;
                                                break;
                                        }
                                    } while (!chosen2);
                                }

                            } while (!end1);

                            break;
                        case "2":
                            chosen1 = true;
                            Console.WriteLine("Enter list name:");
                            var listName = Console.ReadLine();
                            lists[listsCount] = new LinkedList();
                            names[listsCount] = listName;
                            listsCount++;
                            break;
                        case "3":
                            chosen1 = true;
                            end = true;
                            break;
                        default:
                            Console.WriteLine("Wrong option. Try again:");
                            chosen1 = false;
                            break;
                    }
                } while (!chosen1);
            } while (!end);
        }
    }
}