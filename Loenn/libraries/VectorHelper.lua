local ControllerIcon = "VectorHelper/mapping/controller_icon"

local SaveMethod = {
	"SaveData",
	"Session"
}

local OneTimeModes = {
	"False",
	"Session",
	"SaveFile"
}

local VariableTypes = {
	"Variable",
	"Array",
	"List",
	"Dictionary"
}

local DataTypes = {
	{ "String", "String" },
	{ "Character", "Char" },
	{ "Byte", "SByte" },
	{ "Unsigned Byte", "Byte" },
	{ "Integer", "Int" },
	{ "Unsigned Integer", "UInt" },
	{ "Long", "Long" },
	{ "Unsigned Long", "ULong" },
	{ "Float", "Float" },
	{ "Double", "Double" },
	{ "Decimal", "Decimal" },
	{ "Boolean", "Bool" },
	{ "Object", "Object" },
	{ "Vector2", "Vector2" },
	{ "Vector3", "Vector3" },
	{ "Vector4", "Vector4" },
	{ "Color", "Color" },
	{ "EntityData", "EntityData" },
	{ "Dynamic", "Dynamic" }
}

return {
	ControllerIcon = ControllerIcon,
	SaveMethod = SaveMethod,
	OneTimeModes = OneTimeModes,
	VariableTypes = VariableTypes,
	DataTypes = DataTypes
}