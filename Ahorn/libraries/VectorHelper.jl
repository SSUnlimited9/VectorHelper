# VectorHelper library for quick options
# File written by SSUnlimited

module VectorHelper

using ..Ahorn, Maple

const ControllerIcon = "VectorHelper/mapping/controller_icon"
const Unknown = "VectorHelper/mapping/unknown"

# This is basically a copy of flag trigger modes and temple gate modes
# but with the addition of a "OnUpdate" mode
const TriggerModes = String[
	"OnLevelStart",
	"OnLevelEnd",
	"OnPlayerEnter",
	"OnPlayerLeave",
	"OnUpdate"
]

# Slightly expanded from "onlyOnce" boolean (the onlyOnce option would technically be "Session")
const OnlyOnceModes = String[
	"False",
	"Level",
	"Session",
	"SaveFile"
]

# VectorHelper Variable stuff (Specifically types)
const VariableTypes = String[
	"Variable",
	"Array",
	"List",
	"Dictionary"
]

# More VectorHelper Variable stuff (But these are Data Types)
# Dont question why "Byte" is "SByte" and "Unsigned Byte" is "Byte" (Just for user friendliness and to make it easier to code stuff)
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