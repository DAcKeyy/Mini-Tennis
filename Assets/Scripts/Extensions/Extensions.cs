using Unity.VisualScripting;
using UnityEngine;

namespace UnityProject.Extensions
{
	public static class Extensions
	{
		public static float Minimum(this Vector2 variable)
		{
			return variable.x;
		}
		
		public static float Maximum(this Vector2 variable)
		{
			return variable.y;
		}
	}
}