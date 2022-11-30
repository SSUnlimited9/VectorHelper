local drawableSprite = require("structs.drawable_sprite")
local connectedEntities = require("helpers.connected_entities")

local vectorHelper = {}

function vectorHelper.getSearchPredicateCassette(entity)
	return function(target)
		return entity._name == target._name and entity.index == target.index
	end
end

function vectorHelper.getTileSprite(entity, x, y, frame, color, depth, rectangles)
	local hasAdjacent = connectedEntities.hasAdjacent

	local drawX, drawY = (x - 1) * 8, (y - 1) * 8

	local closedLeft = hasAdjacent(entity, drawX - 8, drawY, rectangles)
	local closedRight = hasAdjacent(entity, drawX + 8, drawY, rectangles)
	local closedUp = hasAdjacent(entity, drawX, drawY - 8, rectangles)
	local closedDown = hasAdjacent(entity, drawX, drawY + 8, rectangles)
	local completelyClosed = closedLeft and closedRight and closedUp and closedDown

	local quadX, quadY = 0, 0

	if completelyClosed then
		if not hasAdjacent(entity, drawX + 8, drawY - 8, rectangles) then
			quadX, quadY = 24, 0

		elseif not hasAdjacent(entity, drawX - 8, drawY - 8, rectangles) then
			quadX, quadY = 24, 8

		elseif not hasAdjacent(entity, drawX + 8, drawY + 8, rectangles) then
			quadX, quadY = 24, 16

		elseif not hasAdjacent(entity, drawX - 8, drawY + 8, rectangles) then
			quadX, quadY = 24, 24

		else
			quadX, quadY = 8, 8
		end
	else
		if closedLeft and closedRight and not closedUp and closedDown then
			quadX, quadY = 8, 0

		elseif closedLeft and closedRight and closedUp and not closedDown then
			quadX, quadY = 8, 16

		elseif closedLeft and not closedRight and closedUp and closedDown then
			quadX, quadY = 16, 8

		elseif not closedLeft and closedRight and closedUp and closedDown then
			quadX, quadY = 0, 8

		elseif closedLeft and not closedRight and not closedUp and closedDown then
			quadX, quadY = 16, 0

		elseif not closedLeft and closedRight and not closedUp and closedDown then
			quadX, quadY = 0, 0

		elseif not closedLeft and closedRight and closedUp and not closedDown then
			quadX, quadY = 0, 16

		elseif closedLeft and not closedRight and closedUp and not closedDown then
			quadX, quadY = 16, 16
		end
	end

	if quadX and quadY then
		local sprite = drawableSprite.fromTexture(frame, entity)

		sprite:addPosition(drawX, drawY)
		sprite:useRelativeQuad(quadX, quadY, 8, 8)
		sprite:setColor(color)

		sprite.depth = depth

		return sprite
	end
end

vectorHelper.controllerIcon = "VectorHelper/controller_icon"

vectorHelper.extendedCassetteColors = {
	-- Original Cassette Colors
	{73 / 255, 170 / 255, 240 / 255}, -- Blue
	{240 / 255, 73 / 255, 190 / 255}, -- Rose
	{252 / 255, 220 / 255, 58 / 255}, -- Bright Sun ("Bright" yellow)
	{56 / 255, 224 / 255, 78 / 255}, -- Malachite (Light green)

	-- Extended Cassette Colors 1
	{0 / 255, 0 / 255, 128 / 255}, -- Navy Blue
	{255 / 255, 34 / 255, 0 / 255}, -- Scarlet (Some light red)
	{242 / 255, 133 / 255, 0 / 255}, -- Tangerine (slightly darker than the original yellow (Bright Sun))
	{18 / 255, 53 / 255, 36 / 255}, -- Phthalo (Dark green)

	-- Extended Cassette Colors 2
	{76 / 255, 0 / 255, 130 / 255}, -- Indigo (Fancy purple)
	{128 / 255, 0 / 255, 0 / 255}, -- Maroon (Dark red)
	{204 / 255, 85 / 255, 0 / 255}, -- Burnt Orange (Dark orange)
	{0 / 255, 150 / 255, 100 / 255}, -- Shamrock Green

	-- Extended Cassette Colors 3
	{255 / 255, 255 / 255, 255 / 255}, -- White
	{27 / 255, 27 / 255, 27 / 255}, -- Light Black (Why did I name it this?)
	{0 / 255, 255 / 255, 247 / 255}, -- Light Cyan (Light blue)
	{77 / 255, 54 / 255, 11 / 255} -- Brown (Very slightly dark brown) (Or just a very dark orange)
}

vectorHelper.extendedCassetteColorNames = {
	-- Original
	["0 - Blue"] = 0,
	["1 - Rose"] = 1,
	["2 - Bright Sun"] = 2,
	["3 - Malachite"] = 3,

	-- Extended 1
	["4 - Navy Blue"] = 4,
	["5 - Scarlet"] = 5,
	["6 - Tangerine"] = 6,
	["7 - Phthalo"] = 7,

	-- Extended 2
	["8 - Indigo"] = 8,
	["9 - Maroon"] = 9,
	["10 - Burnt Orange"] = 10,
	["11 - Shamrock Green"] = 11,

	-- Extended 3
	["12 - White"] = 12,
	["13 - Light Black"] = 13,
	["14 - Light Cyan"] = 14,
	["15 - Brown"] = 15
}

return vectorHelper