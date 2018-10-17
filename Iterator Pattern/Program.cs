using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator_Pattern
{
    class Program
    {
        class JellyBean
        {
            private string _flavor;

            // Constructor
            public JellyBean(string flavor)
            {
                _flavor = flavor;
            }

            public string Flavor
            {
                get { return _flavor; }
            }
        }

        interface ICandyCollection
        {
            Iterator CreateIterator();
        }

        class JellyBeanCollection : ICandyCollection
        {
            private ArrayList _items = new ArrayList();

            public Iterator CreateIterator()
            {
                return new Iterator(this);
            }

            // Gets jelly bean count
            public int Count
            {
                get { return _items.Count; }
            }

            public object this[int index]
            {
                get { return _items[index]; }
                set { _items.Add(value); }
            }
        }

        interface IJellyBeanIterator
        {
            JellyBean First();
            JellyBean Next();
            bool IsDone { get; }
            JellyBean CurrentBean { get; }
        }

        class Iterator : IJellyBeanIterator
        {
            private JellyBeanCollection _jellyBeans;
            private int _current = 0;
            private int _step = 1;

            public Iterator(JellyBeanCollection beans)
            {
                _jellyBeans = beans;
            }

            // Gets first jelly bean
            public JellyBean First()
            {
                _current = 0;
                return _jellyBeans[_current] as JellyBean;
            }

            // Gets next jelly bean
            public JellyBean Next()
            {
                _current += _step;
                if (!IsDone)
                    return _jellyBeans[_current] as JellyBean;
                else
                    return null;
            }

            // Gets current iterator candy
            public JellyBean CurrentBean
            {
                get { return _jellyBeans[_current] as JellyBean; }
            }

            // Gets whether iteration is complete
            public bool IsDone
            {
                get { return _current >= _jellyBeans.Count; }
            }
        }

        static void Main(string[] args)
        {
            // Build a collection of jelly beans
            JellyBeanCollection collection = new JellyBeanCollection();
            collection[0] = new JellyBean("Cherry");
            collection[1] = new JellyBean("Bubble Gum");
            collection[2] = new JellyBean("Root Beer");
            collection[3] = new JellyBean("French Vanilla");
            collection[4] = new JellyBean("Licorice");
            collection[5] = new JellyBean("Buttered Popcorn");
            collection[6] = new JellyBean("Juicy Pear");
            collection[7] = new JellyBean("Cinnamon");collection[8] = new JellyBean("Coconut");

            // Create iterator
            Iterator iterator = collection.CreateIterator();

            Console.WriteLine("Gimme all the jelly beans!");

            for (JellyBean item = iterator.First();
                !iterator.IsDone; item = iterator.Next())
            {
                Console.WriteLine(item.Flavor);
            }

            Console.ReadKey();
        }
    }
}
