using GTA.Math;
using GTA.Native;

namespace GTA
{
	public interface ISpatial
	{
		Vector3 Position { get; set; }
		Vector3 Rotation { get; set; }
	}

	public interface IExistable
	{
		bool Exists();
	}

	public interface IDeletable : IExistable
	{
		void Delete();
	}

	public abstract class PoolObject : INativeValue, IDeletable
	{
		protected PoolObject(PoolHandle handle)
		{
			Handle = handle;
		}

		public PoolHandle Handle { get; protected set; }
		public ulong NativeValue
		{
			get { return (ulong)Handle; }
			set { Handle = unchecked((uint)value); }
		}

		public abstract bool Exists();

		public abstract void Delete();
	}
}
