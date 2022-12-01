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
						char @char = ' ';
						try
						{
							@char = char.Parse(value.ToString());
						} catch 
						{ try { @char = char.Parse(value.ToString().Substring(0, 1)); } catch { } }
						return @char;
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