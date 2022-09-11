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
	"String",
	"Character",
	"Byte",
	"Unsigned Byte",
	"Short",
	"Unsigned Short",
	"Integer",
	"Unsigned Integer",
	"Long",
	"Unsigned Long",
	"Float",
	"Double",
	"Decimal",
	"Boolean",
	"Object",
	"Vector2",
	"Vector3",
	"Vector4",
	"Color",
	"EntityData",
	"Dynamic"
}

return {
	ControllerIcon = ControllerIcon,
	SaveMethod = SaveMethod,
	OneTimeModes = OneTimeModes,
	VariableTypes = VariableTypes,
	DataTypes = DataTypes
}