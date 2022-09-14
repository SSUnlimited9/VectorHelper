# File written by SSUnlimited

module VectorHelper

using ..Ahorn, Maple

const ControllerIcon = "VectorHelper/mapping/controller_icon"
const Unknown = "VectorHelper/mapping/unknown"

const TriggerModes = String[
	"OnLevelStart",
	"OnLevelEnd",
	"OnPlayerEnter",
	"OnPlayerLeave",
	"OnUpdate"
]

const OnlyOnceModes = String[
	"False",
	"Level",
	"Session",
	"SaveFile"
]

const VariableTypes = String[
	"Variable",
	"Array",
	"List",
	"Dictionary"
]

const DataTypes = Dict{String, String}(
	"String" => "String",
	"Character" => "Char",
	"Byte" => "SByte",
	"Unsigned Byte" => "Byte",
	"Short" => "Short",
	"Unsigned Short" => "UShort",
	"Integer" => "Int",
	"Unsigned Integer" => "UInt",
	"Long" => "Long",
	"Unsigned Long" => "ULong",
	"Float" => "Float",
	"Double" => "Double",
	"Decimal" => "Decimal",
	"Boolean" => "Bool",
	"Object" => "Object",
	"Vector2" => "Vector2",
	"Vector3" => "Vector3",
	"Vector4" => "Vector4",
	"Color" => "Color",
	"EntityData" => "EntityData",
	"Dynamic" => "Dynamic"
)

end