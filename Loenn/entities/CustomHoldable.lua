-- VectorHelper Custom Holdable (Loenn Integration)
-- Written by KtheVeg

local customHoldable = {}

customHoldable.name = "VectorHelper/BasicCustomHoldable"
customHoldable.justification = {0.5, 0.5}
customHoldable.fieldOrder = {
    "x", "y", "spriteDirectory", "spriteOffset", "visualDepth", "linkedToPlayer", "slowsPlayerDown"
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

function customHoldable.texture(room, entity)
    return entity.spriteDirectory
end

function customHoldable.depth(room, entity)
    return entity.visualDepth
end




return customHoldable