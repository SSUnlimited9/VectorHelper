local vectorHelper = require("mods").requireFromPlugin("libraries.VectorHelper")

local drawableSprite = require("structs.drawable_sprite")

local extendedCassetteController = {}

extendedCassetteController.name = "VectorHelper/ExtendedCassetteController"

extendedCassetteController.placements = {
	{
		name = "default",
		data = {
			customOrder = "",
			overrideMode = 0,
			startIndex = 0,
			skipEmptyIndexes = false,
			tempoModifier = ""
		}
	},
	{
		name = "customOrder",
		data = {
			customOrder = "0,1,2,3",
			overrideMode = 1,
			startIndex = 0,
			skipEmptyIndexes = false,
			tempoModifier = ""
		}
	},
	{
		name = "multiTempo",
		data = {
			customOrder = "",
			overrideMode = 0,
			startIndex = 0,
			skipEmptyIndexes = false,
			tempoModifier = "1.0,1.35,1.85"
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

extendedCassetteController.fieldOrder = {
	"x", "y",
	"overrideMode", "startIndex"
}

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

	local bg = drawableSprite.fromTexture(vectorHelper.controllerBgDark, entity)
	table.insert(sprite, bg)

	local design = drawableSprite.fromTexture("VectorHelper/extended_cassette_controller", entity)
	table.insert(sprite, design)

	local controller = drawableSprite.fromTexture(vectorHelper.controllerIcon, entity)
	table.insert(sprite, controller)

	return sprite
end

return extendedCassetteController