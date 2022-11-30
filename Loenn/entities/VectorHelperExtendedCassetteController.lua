local vectorHelper = require("mods").requireFromPlugin("libraries.VectorHelper")

local drawableSprite = require("structs.drawable_sprite")

local extendedCassetteController = {}

extendedCassetteController.name = "VectorHelper/ExtendedCassetteController"

extendedCassetteController.placements = {
	{
		name = "extended_cassette_controller",
		data = {
			customOrder = "",
			overrideMode = 0,
			startIndex = 0,
			skipEmptyIndexes = false
		}
	}
}

local overrideModes = {
	["None"] = 0,
	["Custom Order"] = 1
}

function extendedCassetteController.ignoredFields(entity)
	local ignoredFields = {"_name", "_id"}

	if entity.overrideMode == 0 then
		table.insert(ignoredFields, "customOrder")
	end

	return ignoredFields
end

extendedCassetteController.fieldInformation = {
	overrideMode = {
		fieldType = "integer",
		options = overrideModes,
		editable = false
	},
	startIndex = {
		fieldType = "integer"
	}
}

function extendedCassetteController.sprite(room, entity, viewport)
	local sprite = {}

	local design = drawableSprite.fromTexture("VectorHelper/extended_cassette_controller", entity)
	table.insert(sprite, design)

	local controller = drawableSprite.fromTexture(vectorHelper.controllerIcon, entity)
	table.insert(sprite, controller)

	return sprite
end

return extendedCassetteController