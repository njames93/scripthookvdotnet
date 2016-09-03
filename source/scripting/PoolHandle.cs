using System;
using GTA.Native;

namespace GTA
{
	[Serializable]
	public struct PoolHandle : IEquatable<PoolHandle>, INativeValue
	{
		public PoolHandle(int handle) : this((uint)handle)
		{
		}
		public PoolHandle(uint handle) : this()
		{
			Value = handle;
		}

		public uint Value { get; private set; }

		public ulong NativeValue
		{
			get { return (ulong)Value; }
			set { Value = unchecked((uint)value); }
		}

		public byte Counter
		{
			get
			{
				return (byte)(Value & 0x000000FF);
			}
		}

		public uint Index
		{
			get
			{
				return Value & 0xFFFFFF00;
			}
		}

		public bool Equals(PoolHandle handle)
		{
			return Value == handle.Value;
		}
		public override bool Equals(object obj)
		{
			return obj != null && obj.GetType() == GetType() && Equals((PoolHandle)obj);
		}

		public override int GetHashCode()
		{
			return (int)Value;
		}

		public override string ToString()
		{
			return "0x" + Value.ToString("X");
		}


		public static implicit operator PoolHandle(uint handle)
		{
			return new PoolHandle(handle);
		}
		public static implicit operator PoolHandle(int handle)
		{
			return new PoolHandle(handle);
		}
		public static implicit operator uint(PoolHandle handle)
		{
			return handle.Value;
		}
		public static implicit operator int(PoolHandle handle)
		{
			return (int)handle.Value;
		}


		public static bool operator ==(PoolHandle left, PoolHandle right)
		{
			return left.Equals(right);
		}
		public static bool operator !=(PoolHandle left, PoolHandle right)
		{
			return !left.Equals(right);
		}
	}
}
