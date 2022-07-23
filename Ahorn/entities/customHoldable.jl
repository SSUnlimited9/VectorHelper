# VectorHelper Customizable Holdable Entities
# File written by SSUnlimited

module VectorHelperCustomHoldable

using ..Ahorn, Maple

@mapdef Entity "VectorHelper/CustomHoldable" CustomHoldable(
	x::Integer, y::Integer,
	spriteDirectory::String="objects/resortclutter/yellow_14"
) # spriteDirectory is the string path relative to Gameplay/ for the sprite


# IGNORE THIS
#@mapdef Entity "VectorHelper/CustomHoldable" CustomHoldable(
#	x::Integer, y::Integer,
#	spriteDirectory::String="objects/resortclutter/yellow_14", spriteOffset::String="0,0",
#	collisionBox::String="22,22,-11,-11", pickupCollisionBox::String="28,28,-14,-14", playerCollider::String="22,22,-11,-11",
#	playerPickupOffset::String="0,0",
#	killOnPickup::Bool=false, killOnCollide::Bool=false, spawnsFloating::Bool=false, playerCanCollide::Bool=false
#)

const placements = Ahorn.PlacementDict(
	"Custom Holdable (Vector Helper)" => Ahorn.EntityPlacement(
		CustomHoldable # The placement for mapping (nothing else is used here since everything is default)
	)
)

Ahorn.editingOrder(entity::CustomHoldable) = String["x", "y", "spriteDirectory"]
# Makes the entity edit window Display like
#	X: 					Y:
#	Sprite Directory

function Ahorn.selection(entity::CustomHoldable)
	x, y = Ahorn.position(entity)
	sprite = get(entity.data, "spriteDirectory", "objects/resortclutter/yellow_14")
	# gets the spriteDirectory String from entity data and converts it to "sprite"
	return Ahorn.getSpriteRectangle(sprite, x, y) # makes the selection the size of the actual Sprite
end

function Ahorn.render(ctx::Ahorn.Cairo.CairoContext, entity::CustomHoldable)
	x = Int(get(entity.data, "x", 0))
	y = Int(get(entity.data, "y", 0))
	sprite = get(entity.data, "spriteDirectory", "objects/resortclutter/yellow_14")
	#Same thing as seelections

	Ahorn.drawSprite(ctx, sprite, 0, 0) # Draws the sprite at the center
end


# IGNORE THIS AREA
#function Ahorn.render(ctx::Ahorn.Cairo.CairoContext, entity::CustomHoldable, room::Maple.Room)
	#x = Int(get(entity.data, "x", 0))
	#y = Int(get(entity.data, "y", 0))
	#sprite = get(entity.data, "spriteDirectory", "objects/resortclutter/yellow_14")
	
	#collisionBoxPreviewRenderString = get(entity.data, "collisionBox", "22,22,-11,-11")
	#collisionBoxPreviewRender = tryparse.(Int, split(collisionBoxPreviewRenderString, ','))
	
	#pickupCollisionBoxPreviewRenderString = get(entity.data, "pickupCollisionBox", "28,28,-14,-14")
	#pickupCollisionBoxPreviewRender = tryparse.(Int, split(pickupCollisionBoxPreviewRenderString, ','))
	
	#spriteOffsetPreviewRenderString = get(entity.data, "spriteOffset", "0,0")
	#spriteOffsetPreviewRender = tryparse.(Int, split(spriteOffsetPreviewRenderString, ','))
	
	#Ahorn.drawSprite(ctx, sprite, spriteOffsetPreviewRender[1], spriteOffsetPreviewRender[2])
	
	#Ahorn.drawRectangle(ctx, collisionBoxPreviewRender[3], collisionBoxPreviewRender[4], collisionBoxPreviewRender[1], collisionBoxPreviewRender[2], (0.0, 0.0, 0.0, 0.0), (1.0, 0.0, 0.0, 0.5))
	
	#Ahorn.drawRectangle(ctx, pickupCollisionBoxPreviewRender[3], pickupCollisionBoxPreviewRender[4], pickupCollisionBoxPreviewRender[1], pickupCollisionBoxPreviewRender[2], (0.0, 0.0, 0.0, 0.0), (0.0, 1.0, 0.0, 0.5))

#end

end