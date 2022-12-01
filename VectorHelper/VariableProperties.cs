using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VectorHelper
{
	public struct VariableProperties
	{
		public string ReadOnlyRooms;
		public string NotReadOnlyRooms;
		public string WriteOnlyRooms;
		public string NotWriteOnlyRooms;

		public VariableProperties(string readOnlyRooms, string notReadOnlyRooms, string writeOnlyRooms, string notWriteOnlyRooms)
		{
			ReadOnlyRooms = readOnlyRooms;
			NotReadOnlyRooms = notReadOnlyRooms;
			WriteOnlyRooms = writeOnlyRooms;
			NotWriteOnlyRooms = notWriteOnlyRooms;
		}
	}
}