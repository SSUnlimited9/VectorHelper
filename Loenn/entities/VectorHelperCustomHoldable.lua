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
customHoldable.justification = {0.5,0.5}
customHoldable.fieldOrder = {
    "x", "y", "spriteDirectory", "spriteOffset", "visualDepth", "linkedToPlayer", "slowsPlayerDown", "spawnId", "interactionId"
}
customHoldable.ignoredFields = {
    "_name", "_id"
}
customHoldable.placements = {
    {
        name = "Custom Holdable (Basic)",
        data = {
            spriteDirectory = "objects/resortclutter/yellow_14",
            spriteOffset ="0,0",
            visualDepth = 100,
            linkedToPlayer = false,
            slowsPlayerDown = false,
            spawnId = "",
            interactionId = "",
            width = 8,
            height = 8
        }
    }
}

function customHoldable.sprite(room, entity)
    local sprites = {}
    local x, y = (entity.x - entity.width) or 0, (entity.y - entity.height) or 0
    local width, height = entity.width * 2, entity.height * 2

    --Main Entity Sprite
    entity.spriteDirectory = entity.spriteDirectory or "objects/resortclutter/yellow_14"

    

    --Insert Main Sprite
    table.insert(sprites, drawableSprite.fromTexture(entity.spriteDirectory, entity))


    --Hitboxes

    --Grab collider
    table.insert(sprites, drawableRectangle.fromRectangle("fill", x, y, width, height, {1.0, 1.0, 1.0, 1.0}))

    --Return Sprite list
    return sprites
end

function customHoldable.depth(room, entity)
    return entity.visualDepth
end



return customHoldable