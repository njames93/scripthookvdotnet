using System.Runtime;
using GTA.Math;
using GTA.Native;

namespace GTA
{
	public static class PoolObjectExtensions 
	{
		public static bool Exists(this PoolObject poolObject)
		{
			return poolObject != null && poolObject.IsValid();
		}
	}
}
