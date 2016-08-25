using System;
using System.Threading;

namespace Ex3_TAP
{
	public class ConcurrentQueue<T>
	{
		private class Node
		{
			public Node Next;
			public readonly T Value;

			public Node(T val)
			{
				Value = val;
				Next = null;
			}
		}

		private Node _head, _tail;

		public ConcurrentQueue()
		{
			Node dummy = new Node(default(T));
			_head = _tail = dummy;
		}

		public void Enqueue(T elem)
		{
			Node newNode = new Node(elem);
			Node tail, next;
			while (true)
			{
				tail = _tail;
				next = tail.Next;
				if (tail == _tail)
				{
					if (next == null)
					{
						if (Interlocked.CompareExchange(ref tail.Next, newNode, next) == next)
							break;
					}
					else
						Interlocked.CompareExchange(ref _tail, next, tail);
				}
			}
			Interlocked.CompareExchange(ref _tail, newNode, tail);
		}

		public T TryDequeue()
		{
			while (true)
			{
				Node head = _head;
				Node tail = _tail;
				Node next = head.Next;
				if (head == _head)
				{
					if (head == tail)
					{
						if (next == null)
						{
							return default(T);
						}
						Interlocked.CompareExchange(ref _tail, next, tail);
					}
					else
					{
						T val = next.Value;
						if (Interlocked.CompareExchange(ref _head, next, head) == head)
							return val;
					}
				}
			}
		}

		public bool IsEmpty()
		{
			return _head == _tail && _head.Next == null;
		}
	}
}
