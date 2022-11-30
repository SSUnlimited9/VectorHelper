local vectorHelper = require("mods").requireFromPlugin("libraries.VectorHelper")

local utils = require("utils")
local drawableSprite = require("structs.drawable_sprite")
local connectedEntities = require("helpers.connected_entities")
local celesteEnums = require("consts.celeste_enums")

local customExtendedCassetteBlock = {}

customExtendedCassetteBlock.name = "VectorHelper/CustomExtendedCassetteBlock"
customExtendedCassetteBlock.minimumSize = {16, 16}

local exColors = {
	"49aaf0", "f049be", "fcdc3a", "38e04e",

	"000080", "ff2200", "f28500", "123524",

	"4c0082", "800000", "cc5500", "009664",
	
	"ffffff", "1b1b1b", "00fff7", "4d360b"
}

function customExtendedCassetteBlock.placements(entity)
	local placements = {}

	table.insert(placements, {
		name = "custom_extended_cassette_block",
		data = {
			width = 16,
			height = 16,
			color = "ffffff",
			index = 16,
			activeSprite = "objects/cassetteblock/solid",
			inactiveSprite = "objects/cassetteblock/pressed00",
			tempo = 1.0,
			surfaceSoundIndex = 35
		}
	})

	for i = 0, 15 do
		local inactive
		if i < 4 then
			inactive = "objects/cassetteblock/pressed0" .. i
		elseif i < 10 then
			inactive = "VectorHelper/cassetteBlock/extended0" .. i
		elseif i == 15 then
			inactive = "VectorHelper/cassetteBlock/empty"
		else
			inactive = "VectorHelper/cassetteBlock/extended" .. i
		end
		table.insert(placements, {
			name = "custom_extended_cassette_block_" .. i,
			data = {
				width = 16,
				height = 16,
				color = exColors[i + 1],
				index = i,
				activeSprite = "objects/cassetteblock/solid",
				inactiveSprite = inactive,
				tempo = 1.0,
				surfaceSoundIndex = 35
			}
		})
	end

	return placements
end

customExtendedCassetteBlock.fieldOrder = {
	"x", "y",
	"width", "height",
	"color", "index",
	"tempo", "surfaceSoundIndex"
}

customExtendedCassetteBlock.fieldInformation = {
	index = {
		fieldType = "integer"
	},
	color = {
		fieldType = "color",
		allowXNAColors = true
	},
	tempo = {
		minimumValue = 0.0
	},
	surfaceSoundIndex = {
		fieldType = "integer",
		options = celesteEnums.tileset_sound_ids
	}
}

function customExtendedCassetteBlock.sprite(room, entity)
	local relevantBlocks = utils.filter(vectorHelper.getSearchPredicateCassette(entity), room.entities)

	connectedEntities.appendIfMissing(relevantBlocks, entity)

	local rectangles = connectedEntities.getEntityRectangles(relevantBlocks)

	local sprites = {}

	local width, height = entity.width or 32, entity.height or 32
	local tileWidth, tileHeight = math.ceil(width / 8), math.ceil(height / 8)

	local color = entity.color or "ff0000"
	local frame = entity.activeSprite or "objects/cassetteblock/solid"
	local depth = -10

	for x = 1, tileWidth do
		for y = 1, tileHeight do
			local sprite = vectorHelper.getTileSprite(entity, x, y, frame, color, depth, rectangles)
			table.insert(sprites, sprite)
		end
	end

	return sprites
end

return customExtendedCassetteBlock