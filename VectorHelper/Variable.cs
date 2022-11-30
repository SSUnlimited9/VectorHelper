namespace VectorHelper
{
	public class Variable
	{
		public enum DataType
		{
			Any = -1,
			String = 0, Char = 1,
			SByte = 2, Byte = 3,
			Short = 4, UShort = 5,
			Int = 6, UInt = 7,
			Long = 8, ULong = 9,
			FLoat = 10, Double = 11, Decimal = 12,
			Bool = 13,
			Vector2 = 14, Vector3 = 15, Vector4 = 16,
			Color = 17, Object = 18,
			EntityData = -10, Dynamic = -11
		}

		public enum Type
		{
			Any = -1,
			Variable = 0,
			Array = 1,
			List = 2,
			Dictionary = 3
		}
	}
}