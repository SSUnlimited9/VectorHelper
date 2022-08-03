-- VectorHelper Custom Holdable (Loenn Integration)
-- Written by KtheVeg

--Loenn Libs
local drawableSprite = require "structs.drawable_sprite"
local drawableRectangle = require "structs.drawable_rectangle"

function Split (inputstr, sep)
        if sep == nil then
                sep = "%s"
        end
        local t={}
        for str in string.gmatch(inputstr, "([^"..sep.."]+)") do
                table.insert(t, str)
        end
        return t
end

local customHoldable = {}

customHoldable.name = "VectorHelper/BasicCustomHoldable"
customHoldable.justification = {0.5, 0.5}
customHoldable.fieldOrder = {
    "x", "y", "spriteDirectory", "spriteOffset", "visualDepth", "linkedToPlayer", "slowsPlayerDown", "spawnId", "interactionId"
}
customHoldable.placements = {
    {
        name = "Custom Holdable (Basic)",
        data = {
            spriteDirectory = "objects/resortclutter/yellow_14",
            spriteOffset = "0,0",
            visualDepth = 100,
            linkedToPlayer = false,
            slowsPlayerDown = false,
            spawnId = "",
            interactionId = ""
        }
    }
}

function customHoldable.sprite(room, entity)
    entity.x, entity.y = (entity.x + (Split(entity.spriteOffset, ",")[1] or 0)) or 0, (entity.y + (Split(entity.spriteOffset, ",")[2] or 0)) or 0
    entity.spriteDirectory = entity.spriteDirectory or "objects/resortclutter/yellow_14"
    local sprites = {}

    table.insert(sprites, drawableSprite.fromTexture(entity.spriteDirectory, entity))

    return sprites
end

function customHoldable.depth(room, entity)
    return entity.visualDepth
end




return customHoldable