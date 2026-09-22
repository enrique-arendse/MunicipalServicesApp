using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp.Data
{
	/// <summary>
	/// A minimal binary-heap priority queue. .NET Framework 4.8 does not
	/// ship a PriorityQueue&lt;TElement, TPriority&gt; type (that was only
	/// added in .NET 6), so this is a small hand-rolled implementation
	/// used to satisfy the "priority queue" technical requirement and to
	/// always give quick access to the event with the lowest priority
	/// value (in this application, the soonest date).
	/// </summary>
	/// <typeparam name="TElement">Type of item stored.</typeparam>
	/// <typeparam name="TPriority">Comparable priority (lower = higher priority).</typeparam>
	public class PriorityQueue<TElement, TPriority> where TPriority : IComparable<TPriority>
	{
		private readonly List<(TElement Element, TPriority Priority)> _heap = new List<(TElement, TPriority)>();

		public int Count => _heap.Count;

		public void Enqueue(TElement element, TPriority priority)
		{
			_heap.Add((element, priority));
			int i = _heap.Count - 1;

			while (i > 0)
			{
				int parent = (i - 1) / 2;
				if (_heap[i].Priority.CompareTo(_heap[parent].Priority) >= 0) break;

				Swap(i, parent);
				i = parent;
			}
		}

		public TElement Dequeue()
		{
			if (_heap.Count == 0) throw new InvalidOperationException("Priority queue is empty.");

			var root = _heap[0].Element;
			int last = _heap.Count - 1;
			_heap[0] = _heap[last];
			_heap.RemoveAt(last);

			int i = 0;
			while (true)
			{
				int left = 2 * i + 1;
				int right = 2 * i + 2;
				int smallest = i;

				if (left < _heap.Count && _heap[left].Priority.CompareTo(_heap[smallest].Priority) < 0) smallest = left;
				if (right < _heap.Count && _heap[right].Priority.CompareTo(_heap[smallest].Priority) < 0) smallest = right;
				if (smallest == i) break;

				Swap(i, smallest);
				i = smallest;
			}

			return root;
		}

		public bool TryPeek(out TElement element)
		{
			if (_heap.Count == 0)
			{
				element = default;
				return false;
			}

			element = _heap[0].Element;
			return true;
		}

		private void Swap(int a, int b)
		{
			var temp = _heap[a];
			_heap[a] = _heap[b];
			_heap[b] = temp;
		}
	}
}
