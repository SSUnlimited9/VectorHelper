# File Written by SSUnlimited

module VectorHelperVariableController

using ..Ahorn, Maple
using ..Ahorn.VectorHelper

@mapdef Entity "VectorHelper/VariableController" VariableController(
	x::Integer, y::Integer,
	type::String="Variable", variableName::String="myVariable",
	arrayLength::Integer=1, dataType::String="String", value::String="",
	flag::String="", registerInSave::Bool=true,
)

const placements = Ahorn.PlacementDict(
	"Variable Controller (Vector Helper)" => Ahorn.EntityPlacement(
		VariableController
	),
	"Array Controller (Vector Helper)" => Ahorn.EntityPlacement(
		VariableController,
		"point",
		Dict{String, Any}(
			"type" => "Array",
			"variableName" => "myArray"
		)
	)
)

Ahorn.editingOptions(entity::VariableController) = Dict{String, Any}(
	"type" => String["Variable", "Array"],
	"dataType" => String["String", "Integer", "Float", "Boolean"]
)

Ahorn.editingOrder(entity::VariableController) = String[
	"x", "y",
	"type", "arrayLength", "dataType",
	"variableName", "value",
	"flag", "registerInSave"
]

function Ahorn.selection(entity::VariableController)
	x, y = Ahorn.position(entity)
	return Ahorn.getSpriteRectangle(VectorHelper.controller, x, y)
end

function Ahorn.render(ctx::Ahorn.Cairo.CairoContext, entity::VariableController)
	x = Int(get(entity.data, "x", 0))
	y = Int(get(entity.data, "y", 0))
	controllerSprite = VectorHelper.controller
	cogSprite = "VectorHelper/mapping/config_addon"

	sprite = ""
	typeOx = 0
	typeOy = 0
	# Change the sprite based on the type
	# and the offset based on the type
	if entity.type == "Variable"
		sprite = "VectorHelper/mapping/var_icon"
		typeOx = 2
		typeOy = 3
	elseif  entity.type == "Array"
		sprite = "VectorHelper/mapping/array_icon"
		typeOx = 1
		typeOy = 3
	else
		sprite = VectorHelper.unknown
		typeOx = 4
		typeOy = 2
	end

	Ahorn.drawSprite(ctx, cogSprite, -5, -4)
	Ahorn.drawSprite(ctx, controllerSprite, 0, 0)
	Ahorn.drawSprite(ctx, sprite, typeOx, typeOy)

end

function Ahorn.editingIgnored(entity::VariableController, multiple::Bool=false)
	rType = get(entity.data, "type", "Variable")
	result = String["arrayLength"]
	# Remove arrayLength if type is not Array
	if rType != "Variable"
		deleteat!(result, findall(x->x=="arrayLength", result))
	end
	return result
end

end