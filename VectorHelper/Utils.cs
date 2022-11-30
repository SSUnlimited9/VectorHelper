namespace VectorHelper.Utils
{
	public class VUtils
	{
		public class Convert
		{
			public static object ValueByDataType(object value, Variable.DataType dt)
			{
				switch (dt)
				{
					case Variable.DataType.Char:
						try
						{
							return char.Parse(value.ToString());
						} catch
						{
							try
							{
								return char.Parse(value.ToString().Substring(0, 1));
							} catch // This shouldnt happen, but just in case.
							{
								return (char)' ';
							}
						}
					case Variable.DataType.EntityData:
						// Return nothing since EntityData is handled differently.
						return null;
					default:
						// This applies to String, Object and Dynamic (and Any)
						return value;
				}
			}
		}
	}
}