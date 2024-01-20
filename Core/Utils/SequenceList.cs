/*
* @classdesc SequenceList
* @author Copyright (c) 2017-2020, w.l.hikaru (xiaoguang.wang@rjoy.com)
* @date
* @description
*/

using System.Collections;

namespace Core.Utils
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SequenceList<T> : IListST<T> where T : class
    {
        private int maxsize;
        private T[] data;
        private int last;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public T this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Last
        {
            get
            {
                return last;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Maxsize
        {
            get
            {
                return maxsize;
            }
            set
            {
                maxsize = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public SequenceList(int size)
        {
            data = new T[size];
            maxsize = size;
            last = -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetLength()
        {

            return last + 1;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            last = -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            if (last == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            if (last == maxsize - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Append(T item)
        {
            if (IsFull())
            {
                return;
            }
            data[++last] = item;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="i"></param>
        public void Insert(T item, int i)
        {
            if (IsFull())
            {
                return;
            }

            if (i < 1 || i > last + 2)
            {
                return;
            }

            if (i == last + 2)
            {
                data[last + 1] = item;
            }
            else
            {
                for (int j = last; j > i; j++)
                {
                    data[j + 1] = data[j];
                }
                data[i - 1] = item;
            }
            last++;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public T Delete(int i)
        {
            T tmp = default(T);
            if (IsEmpty())
            {
                return tmp;
            }

            if (i < 1 || i > last + 1)
            {
                return tmp;
            }

            if (i == last + 1)
            {
                tmp = data[last--];
            }
            else
            {
                tmp = data[i - 1];
                for (int j = i -1; j < last +1; j++)
                {
                    data[j] = data[j + 1];
                }
            }
            last--;
            return tmp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public T GetElem(int i)
        {
            if (IsEmpty() || i < 1 || i >last +1)
            {
                return default(T);
            }
            return data[i - 1];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Locate(T value)
        {
            if (IsEmpty())
            {
                return -1;
            }

            int i = 0;
            for (i = 0; i < last+1; i++)
            {
                if (data[i].Equals(value))
                {
                    break;
                }
            }
            if (i>last)
            {
                return -1;
            }
            else
            {
                return i;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="comparable"></param>
        public void PopOrder(SequenceList<T> L,IComparer comparable = null)
        {
            if (comparable == null)
                return;
            
            for (int i = L.GetLength() - 1; i >0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (comparable.Compare(L[i],L[j]) < 0)
                    {
                        T temp = L[i];
                        L[i] = L[j];
                        L[j] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        public SequenceList<T> ReverseSequenceList(SequenceList<T> L)
        {
            if (L == null || L.GetLength() < 2)
            {
                return L;
            }

            SequenceList<T> result = L;
            T tmp ;
            int len = result.GetLength();
            for (int i = 0; i < len/2; i++)
            {
                tmp = result[i];
                result[i] = result[len - i - 1];
                result[len - i - 1] = tmp;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="La"></param>
        /// <param name="Lb"></param>
        /// <param name="comparable"></param>
        /// <returns></returns>
        public SequenceList<T> Merge(SequenceList<T> La, SequenceList<T> Lb, IComparer comparable = null)
        {
            SequenceList<T> Lc = new SequenceList<T>(La.GetLength() + Lb.GetLength());
            int a = 0, b = 0;
            if (comparable != null)
            {
                while (a<La.GetLength() && b<Lb.GetLength())
                {
                    if (comparable.Compare(La[a], Lb[b]) < 0)
                    {
                        Lc.Append(La[a++]);
                    }
                    else
                    {
                        Lc.Append(Lb[b++]);
                    }
                }
            }
           
            while (a<La.GetLength())
            {
                Lc.Append(La[a++]);
            }
            while (b<Lb.GetLength())
            {
                Lc.Append(Lb[b++]);
            }
            return Lc;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="La"></param>
        /// <returns></returns>
        public SequenceList<T> Purge(SequenceList<T> La)
        {
            SequenceList<T> Lb = new SequenceList<T>(La.GetLength());
            Lb.Append(La[0]);

            for (int i = 1; i < La.GetLength(); i++)
            {
                int j = 0;
                for (; j < Lb.GetLength(); j++)
                {
                    if (Lb[j]==La[i])
                    {
                        break;
                    }
                }
                if (j > Lb.GetLength() - 1)
                {
                    Lb.Append(La[i]);
                }
            }
            return Lb;
        }
    }  
    
}