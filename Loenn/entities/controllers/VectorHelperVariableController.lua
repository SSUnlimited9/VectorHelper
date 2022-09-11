-- VectorHelper Variable Controller (Loenn Integration)
-- Written by SSUnlimited

local drawableSprite = require("structs.drawable_sprite")

local vectorHelper = require("mods").requireFromPlugin("libraries.VectorHelper")

local variableController = {}

variableController.name = "VectorHelper/VariableController"
variableController.depth = -10000
variableController.placements = {
	{
		name = "variable_controller",
		data = {
			type = "Variable",
			dataType = "String",
			variableName = "myVariable",
			initialValue = "",
			variableFor = "SaveData",
			oneTime = "False",
			arrayLength = "1"

		}
	}
}

function variableController.ignoredFields(entity)
	local ignored = {"_id", "_name", "arrayLength"}

	if entity.type == "Array" then
		table.remove(ignored, 3)
		table.remove(ignored, 2)
	end

	return ignored
end

variableController.fieldOrder = {
	"x", "y",
	"type", "dataType",
	"variableName", "initialValue",
	"variableFor", "oneTime",
	"arrayLength"
}

function variableController.fieldInformation(entity)
	local fields = {
		type = {
			options = vectorHelper.VariableTypes,
			editable = false
		},
		dataType = {
			options = vectorHelper.DataTypes,
			editable = false
		},
		variableFor = {
			options = vectorHelper.SaveMethod,
			editable = false
		},
		oneTime = {
			options = vectorHelper.OneTimeModes,
			editable = false
		}
	}

	return fields
end

function variableController.sprite(room, entity, viewport)
	local sprite = {}
	local x, y = entity.x, entity.y

	local configSprite = drawableSprite.fromTexture("VectorHelper/mapping/config_icon", entity)
	configSprite:setPosition(x - 5, y - 5)
	table.insert(sprite, configSprite)

	local controller = drawableSprite.fromTexture(vectorHelper.ControllerIcon, entity)
	table.insert(sprite, controller)

	local typeSprite
	if entity.type == "Variable" then
		typeSprite = drawableSprite.fromTexture("VectorHelper/mapping/variable_icon", entity)
		typeSprite:setPosition(x + 2, y + 3)
	elseif entity.type == "Array" then
		typeSprite = drawableSprite.fromTexture("VectorHelper/mapping/array_icon", entity)
		typeSprite:setPosition(x, y + 3)
	elseif entity.type == "List" then
		typeSprite = drawableSprite.fromTexture("VectorHelper/mapping/list_icon", entity)
		typeSprite:setPosition(x + 2, y + 4)
	elseif entity.type == "Dictionary" then
		typeSprite = drawableSprite.fromTexture("VectorHelper/mapping/dictionary_icon", entity)
		typeSprite:setPosition(x + 2, y + 4)
	else
		typeSprite = drawableSprite.fromTexture("VectorHelper/mapping/unknown", entity)
		typeSprite:setPosition(x + 4, y + 2)
	end

	table.insert(sprite, typeSprite)

	return sprite
end

return variableController