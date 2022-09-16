# File written by SSUnlimited

module VectorHelperVariableController

using ..Ahorn, Maple
using Ahorn.VectorHelper

@mapdef Entity "VectorHelper/VariableController" VariableController(
	x::Integer, y::Integer,
	type::String="Variable", dataType::String="String",
	variableName::String="myVariable", initialValue::String="",
	variableFor::String="SaveData", onlyOnce::String="False",
	setMode::String="OnLevelStart" , arrayLength::String="1"
)

const placements = Ahorn.PlacementDict(
	"Variable Controller (Variables) (Vector Helper)" => Ahorn.EntityPlacement(
		VariableController
	),
	"Array Controller (Variables) (Vector Helper)" => Ahorn.EntityPlacement(
		VariableController,
		"point",
		Dict{String, Any}(
			"type" => "Array",
			"variableName" => "myArray"
		)
	),
	"List Controller (Variables) (Vector Helper)" => Ahorn.EntityPlacement(
		VariableController,
		"point",
		Dict{String, Any}(
			"type" => "List",
			"variableName" => "myList"
		)
	),
	"Dictionary Controller (Variables) (Vector Helper)" => Ahorn.EntityPlacement(
		VariableController,
		"point",
		Dict{String, Any}(
			"type" => "Dictionary",
			"variableName" => "myDictionary"
		)
	)
)

Ahorn.editingOptions(entity::VariableController) = Dict{String, Any}(
	"type" => VectorHelper.VariableTypes,
	"dataType" => VectorHelper.DataTypes,
	"variableFor" => String["SaveData", "Session"],
	"onlyOnce" => VectorHelper.OnlyOnceModes,
	"setMode" => String[ "OnLevelStart", "OnLevelEnd", "OnUpdate" ]
)

Ahorn.editingOrder(entity::VariableController) = String[
	"x", "y",
	"type", "dataType",
	"variableName", "initialValue",
	"variableFor", "onlyOnce",
	"setMode", "arrayLength"
]

function Ahorn.selection(entity::VariableController)
	x, y = Ahorn.position(entity)
	return Ahorn.getSpriteRectangle(VectorHelper.ControllerIcon, x, y)
end

function Ahorn.renderAbs(ctx::Ahorn.Cairo.CairoContext, entity::VariableController, room::Maple.Room)
	x, y = Ahorn.position(entity)

	sprite = VectorHelper.Unknown
	offsetX = 4
	offsetY = 2

    # Change the sprite and offset/position based on the type
	if entity.type == "Variable"
		sprite = "VectorHelper/mapping/variable_icon"
		offsetX = 3
		offsetY = 3
	elseif entity.type == "Array"
		sprite = "VectorHelper/mapping/array_icon"
		offsetX = 1
		offsetY = 3
	elseif entity.type == "List"
		sprite = "VectorHelper/mapping/list_icon"
		offsetX = 3
		offsetY = 4
	elseif entity.type == "Dictionary"
		sprite = "VectorHelper/mapping/dictionary_icon"
		offsetX = 2
		offsetY = 4
	end

	# Draw the gear before the controller sprite so it appears below
	Ahorn.drawSprite(ctx, "VectorHelper/mapping/gear_icon", x - 5, y - 4)
	Ahorn.drawSprite(ctx, VectorHelper.ControllerIcon, x, y)

	# Then the variable type (Variable, Array, etc.)
	Ahorn.drawSprite(ctx, sprite, x + offsetX, y + offsetY)
end

function Ahorn.editingIgnored(entity::VariableController, multiple::Bool=false)
	hide = String[]

    # Hide "arrayLength" if the type is not "Array" so users dont edit it for no reason
	if entity.type != "Array"
		push!(hide, "arrayLength")
	end	

	return hide
end

end