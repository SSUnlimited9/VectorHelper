-- VectorHelper Variable Controller (Loenn Integration)
-- Written by SSUnlimited

local drawableSprite = require("structs.drawable_sprite")

local vectorHelper = require("mods").requireFromPlugin("libraries.VectorHelper")

local variableController = {}

variableController.name = "VectorHelper/VariableController"
variableController.depth = -math.huge
variableController.placements = {
	{
		name = "variable_controller",
		data = {
			type = "Variable",
			dataType = "String",
			variableName = "myVariable",
			initialValue = "",
			variableFor = "SaveData",
			oneTime = "false",
			arrayLength = "1"

		}
	},
	{
		name = "array_controller",
		data = {
			type = "Array",
			dataType = "String",
			variableName = "myArray",
			initialValue = "",
			variableFor = "SaveData",
			oneTime = "false",
			arrayLength = "1"
		}
	}
}
variableController.fieldOrder = {
	"x", "y",
	"type", "dataType",
	"variableName", "initialValue",
	"variableFor", "oneTime",
	"arrayLength"
}
variableController.fieldInformation = {
	type = {
		options = {
			{
				"Array", "Array"
			},
			{
				"Variable", "Variable"
			}
		}
	},
	dataType = {
		options = require("mods").requireFromPlugin("entities.dataTypes")
	}
}

--function variableController.fieldInformation(entity)
--	local fields = {}
--
--	table.insert(fields, entity.type {
--		options = vectorHelper.VariableTypes,
--		editable = false
--		}
--	)
--
--	return fields
--end

function variableController.ignoredFields(entity)
	local ignored = {"_id", "_name", "arrayLength", "type"}

	print("Before Checking Array")
	for i, v in ipairs(ignored) do
		print(v)
	end

	if entity.type == "Array" then
		table.remove(ignored, 3)
	end

	print("After Checking Array")
	for i, v in ipairs(ignored) do
		print(v)
	end

	return ignored
end

function variableController.sprite(room, entity, viewport)
	local controller = drawableSprite.fromTexture("VectorHelper/mapping/controller_icon", entity)

	return controller
end

return variableController