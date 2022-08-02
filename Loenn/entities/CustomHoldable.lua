-- VectorHelper Custom Holdable (Loenn Integration)
-- Written by KtheVeg

local customHoldable = {}

customHoldable.name = "VectorHelper/BasicCustomHoldable"
customHoldable.justification = {0.5, 0.5}
customHoldable.fieldOrder = {
    "x", "y", "spriteDirectory", "spriteOffset", "entityDepth", "linkedToPlayer", "slowsPlayerDown"
}
customHoldable.placements = {
    {
        name = "Custom Holdable",
        data = {
            spriteDirectory = "objects/resortclutter/yellow_14",
            spriteOffset = "0,0",
            entityDepth = 100,
            linkedToPlayer = false,
            slowsPlayerDown = false
        }
    }
}

function customHoldable.texture(room, entity)
    return entity.spriteDirectory
end

function customHoldable.depth(room, entity)
    return entity.entityDepth
end




return customHoldable