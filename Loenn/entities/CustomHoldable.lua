-- VectorHelper Custom Holdable (Loenn Integration)
-- Written by KtheVeg

local customHoldable = {}

customHoldable.name = "VectorHelper/CustomHoldable"
customHoldable.depth = 100
customHoldable.justification = {0.5, 0.5}

customHoldable.placements = {
    {
        name = "Custom Holdable",
        data = {
            spriteDirectory = "objects/resortclutter/yellow_14"
        }
    }
}

function customHoldable.texture(room, entity)
    return entity.spriteDirectory
end


return customHoldable