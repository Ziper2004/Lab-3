using System;

namespace Лаба_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Map map = new Map();
            map.Put(new Key("Xiaomi", 100), 100.0);
            Console.WriteLine(map.Remove(new Key("Xiaomi", 800)));
            Console.WriteLine();




              map.Put(new Key("Xiaomi", 100), 110.5);
              map.Put(new Key("Xiaomi", 200), 205.0);
              map.Put(new Key("Xiaomi", 300), 300.0);
              map.Put(new Key("Xiaomi", 400), 440.1);
              map.Put(new Key("Xiaomi", 500), 500.6);
              map.Put(new Key("Xiaomi", 600), 650.0);
              map.Put(new Key("Xiaomi", 700), 700.0);
              map.Put(new Key("Xiaomi", 800), 800.0);
              map.Put(new Key("Xiaomi", 900), 900.9);
            
                        Console.WriteLine(map.Size());

                        Console.WriteLine(map.ConstainsKeys(new Key("Xiaomi", 802)));
                        Console.WriteLine(map.ConstainsKeys(new Key("Xiaomi", 800)));
                        Console.WriteLine(map.Get(new Key("Xiaomi", 800)));

                        Console.WriteLine(map.Get(new Key("Xiaomi", 100)));
                        Console.WriteLine(map.Get(new Key("Xiaomi", 200)));
                        Console.WriteLine(map.Get(new Key("Xiaomi", 300)));
                        Console.WriteLine(map.Get(new Key("Xiaomi", 400)));
                        Console.WriteLine(map.Get(new Key("Xiaomi", 500)));
                        Console.WriteLine(map.Get(new Key("Xiaomi", 600)));
                        Console.WriteLine(map.Get(new Key("Xiaomi", 700)));
                        Console.WriteLine(map.Get(new Key("Xiaomi", 800)));
                        Console.WriteLine(map.Get(new Key("Xiaomi", 900)));
                        Console.WriteLine(map.Remove(new Key("Xiaomi", 700)));// ?????
                        Console.WriteLine(map.ConstainsKeys(new Key("Xiaomi", 700)));
                        Console.WriteLine(map.Get(new Key("Xiaomi", 100)));
                        Console.WriteLine(map.Get(new Key("Xiaomi", 200)));
                        Console.WriteLine(map.Get(new Key("Xiaomi", 300)));
                        Console.WriteLine(map.Get(new Key("Xiaomi", 400)));
                        Console.WriteLine(map.Get(new Key("Xiaomi", 500)));
                        Console.WriteLine(map.Get(new Key("Xiaomi", 600)));
                        Console.WriteLine(map.Get(new Key("Xiaomi", 700)));
                        Console.WriteLine(map.Get(new Key("Xiaomi", 800)));
                        Console.WriteLine(map.Get(new Key("Xiaomi", 900)));
                        Console.WriteLine(map.Size());
        }
    }
    class Key
    {
        string stock;
        int dayOfYear;

        public Key(string stock, int dayOfYear)
        {
            this.stock = stock;
            this.dayOfYear = dayOfYear;
        }

        public int hash()
        {
            return dayOfYear;
        }

        public bool eq(Key other)
        {
            return this.stock == other.stock && this.dayOfYear == other.dayOfYear;
        }
    }
    class Node
    {
        public Key key;
        public double value;
        public Node next;
        public Node(Key key, double value, Node next)
        {
            this.key = key;
            this.value = value;
            this.next = next;
        }
    }
    class Map
    {
        Node[] nodes = new Node[8];
        public void Put(Key key, double value)
        {
            
            int hashCode = key.hash();
            int index = Math.Abs(hashCode) % nodes.Length;
            if (nodes[index] == null)
            {
                nodes[index] = new Node(key, value, null);
                size++;
            }
            else
            {
                Node cur = nodes[index];
                while (cur != null)
                {
                    if (cur.key.eq(key))
                    {
                        cur.value = value;
                        
                        return;
                    }
                    cur = cur.next;
                }
                size++;
                nodes[index] = new Node(key, value, nodes[index]);
            }
            
        }
        public double? Get(Key key)
        {
            int hashCode = key.hash();
            int index = Math.Abs(hashCode) % nodes.Length;
            Node cur = nodes[index];
            while (cur != null)
            {
                if (cur.key.eq(key))
                {
                    return cur.value;
                }
                cur = cur.next;
            }
            return null;
        }
        public bool ConstainsKeys(Key key)
        {
            int hashCode = key.hash();
            int index = Math.Abs(hashCode) % nodes.Length;
            Node cur = nodes[index];
            while (cur != null)
            {
                if (cur.key.eq(key))
                {
                    return true;
                }
                cur = cur.next;
            }
            return false;
        }
        public bool Remove(Key key)
        {
            
            int hashCode = key.hash();
            int index = Math.Abs(hashCode) % nodes.Length;
            Node cur = nodes[index];
            Node pr;
            if (nodes[index] == null)
            {
                return false;
            }
            if (nodes[index].next == null && key.eq(nodes[index].key))
            {
                nodes[index] = null;
                size--;
                return true;
                
            }
            else
            {
                pr = nodes[index];
                cur = pr.next;
                while(cur != null)
                {
                    if (cur.key.eq(key))
                    {
                        pr.next = cur.next;
                        size--;
                        return true;

                    }else if (pr.key.eq(key))
                    {
                        nodes[index] = cur;
                        size--;
                        return true;
                    }
                    pr = cur;
                    cur = pr.next;
                }
            }
            return false;
        }
        public int size = 0;
        public int Size()
        {
            int size = 0;
            for (int i = 0; i < nodes.Length; i++)
            {
                Node cur = nodes[i];
                while (cur != null)
                {
                    size++;
                    cur = cur.next;
                }
            }
            return size;
        }
        public Node[] ReSize(Node[] nodes)
        {
            Node[] newNodes = new Node[nodes.Length * 2];
            for (int i = 0; i < nodes.Length; i++)
            {
                Node cur = nodes[i];
                if (cur.key != null)
                {
                    Put(cur.key, Convert.ToDouble(Get(cur.key)));
                }
                else
                {
                    cur = cur.next;
                }
                
            }

            return newNodes;
        }
    }
}   
    