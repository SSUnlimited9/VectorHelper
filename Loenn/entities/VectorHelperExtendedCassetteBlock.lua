local vectorHelper = require("mods").requireFromPlugin("libraries.VectorHelper")

local utils = require("utils")
local drawableSprite = require("structs.drawable_sprite")
local connectedEntities = require("helpers.connected_entities")

local extendedCassetteBlock = {}

extendedCassetteBlock.name = "VectorHelper/ExtendedCassetteBlock"
extendedCassetteBlock.minimumSize = {16, 16}

function extendedCassetteBlock.placements(entity)
	local placements = {}

	for i = 0, 15 do
		table.insert(placements, {
			name = "c" .. i,
			data = {
				width = 16,
				height = 16,
				index = i,
				tempo = 1.0
			}
		})
	end

	return placements
end

extendedCassetteBlock.fieldInformation = {
	index = {
		fieldType = "integer",
		options = vectorHelper.extendedCassetteColorNames,
		editable = false
	},
	tempo = {
		minimumValue = 0.0
	}
}

function extendedCassetteBlock.sprite(room, entity)
	local relevantBlocks = utils.filter(vectorHelper.getSearchPredicate(entity), room.entities)

	connectedEntities.appendIfMissing(relevantBlocks, entity)

	local rectangles = connectedEntities.getEntityRectangles(relevantBlocks)

	local sprites = {}

	local width, height = entity.width or 32, entity.height or 32
	local tileWidth, tileHeight = math.ceil(width / 8), math.ceil(height / 8)

	local index = entity.index or 0
	local color = vectorHelper.extendedCassetteColors[index + 1] or vectorHelper.extendedCassetteColors[1]
	local frame = "objects/cassetteblock/solid"
	local depth = -10

	for x = 1, tileWidth do
		for y = 1, tileHeight do
			local sprite = vectorHelper.getTileSprite(entity, x, y, frame, color, depth, rectangles)

			if sprite then
				table.insert(sprites, sprite)
			end
		end
	end

	return sprites
end

return extendedCassetteBlock